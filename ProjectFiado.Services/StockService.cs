using ProjectFiado.Domain.Models;
using ProjectFiado.Domain.Models.DTOs.StockDTOS;
using ProjectFiado.Mapper;
using ProjectFiado.Repository.Interfaces;
using ProjectFiado.Validation;
using Serilog;
using System;
using System.Threading.Tasks;

namespace ProjectFiado.Services
{
    public class StockService
    {
        private readonly IStock _stockRepository;
        private readonly StockMapper _stockMapper;

        public StockService(IStock stockRepository, StockMapper stockMapper)
        {
            _stockRepository = stockRepository;
            _stockMapper = stockMapper;
        }

        public async Task<ResponseStockDTO> AddProduct(int productId, RequestStockDTO requestStockDTO)
        {
            StockValidate.Validate(requestStockDTO);

            var stockModel =  _stockMapper.RequestStockToModel(requestStockDTO);

            var createdStock = await _stockRepository.AddProduct(productId, stockModel);

            var responseStockDTO = _stockMapper.StockModelToResponse(createdStock);

            return responseStockDTO;
        }

        public async Task<ResponseStockDTO> GetById(int id)
        {
            var stockModel = await _stockRepository.GetById(id);

            ResponseStockDTO responseStockDTO = _stockMapper.StockModelToResponse(stockModel);

            return responseStockDTO;
        }

        public async Task<ResponseStockDTO> RemoveProductInStock(int id)
        {
            var existingProduct = await _stockRepository.GetById(id);

            if (existingProduct != null)
            {
                 await _stockRepository.RemoveStock(existingProduct.Id);

                Log.Information("Product delete");

                ResponseStockDTO responseStockDTO = _stockMapper.StockModelToResponse(existingProduct);
                return responseStockDTO;
            }
            throw new KeyNotFoundException("Estoque não encontrado.");

        }

        public async Task<ResponseStockDTO> AlterProductQuantity(int id, int quantity)
        {
            var updateStock = await _stockRepository.AlterProduct(id, quantity);
            ResponseStockDTO response = _stockMapper.StockModelToResponse(updateStock);
            return response;

        }
    }
}
