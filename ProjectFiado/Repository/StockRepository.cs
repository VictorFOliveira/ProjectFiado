using Microsoft.EntityFrameworkCore;
using ProjectFiado.Data;
using ProjectFiado.Mapper;
using ProjectFiado.Models;
using ProjectFiado.Models.DTOs;
using ProjectFiado.Repository.Interfaces;
using ProjectFiado.Validation;

namespace ProjectFiado.Repository
{
    public class StockRepository : IStock
    {
        private readonly FiadoDBContext _dbContext;
        private readonly StockMApper _mapper;

        public StockRepository(FiadoDBContext dBContext)
        {
            _dbContext = dBContext;
            _mapper = new StockMApper();
        }
        public async Task<ResponseStockDTO> AddProduct(RequestStockDTO requestStockDTO)
        {
            StockValidate.Validate(requestStockDTO);

            StockModel product = _mapper.RequestStockToStockModel(requestStockDTO);

            await _dbContext.stocks.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            ResponseStockDTO responseStockDTO = _mapper.StockModelToResponse(product);

            return responseStockDTO;

        }

        public async Task<ResponseStockDTO> AlterValidateProduct(int id, RequestStockDTO requestStockDTO)
        {
            StockValidate.Validate(requestStockDTO);

            StockModel updateProductId = await _dbContext.stocks.FirstOrDefaultAsync(x => x.ProductId == id);

            if (updateProductId == null)
            {
                throw new Exception("nulo");
            }

            updateProductId.Quantity = requestStockDTO.Quantity;
            updateProductId.Validate = requestStockDTO.Validate;

            await _dbContext.SaveChangesAsync();

            ResponseStockDTO responseStockDTO = _mapper.StockModelToResponse(updateProductId);
            return responseStockDTO;

        }

        public async Task<bool> DeleteProduct(int id)
        {
            var productId = await _dbContext.stocks.FirstOrDefaultAsync(x => x.ProductId == id);

            if (productId == null)
            {
                throw new KeyNotFoundException("Produto não encontrado.");
            }

            _dbContext.stocks.Remove(productId);

            await _dbContext.SaveChangesAsync();

            return true;
        }


        public async Task<ResponseStockDTO> GetProductById(int id)
        {
            StockModel stockModel = await _dbContext.stocks.FirstOrDefaultAsync(x=> x.ProductId == id);

            if(stockModel == null)
            {
                throw new KeyNotFoundException("nulo");

            }

            ResponseStockDTO response =  _mapper.StockModelToResponse(stockModel);
            return response;
        }
    }
}
