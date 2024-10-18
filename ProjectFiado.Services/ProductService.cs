using ProjectFiado.Domain.Models.DTOs.ProductDTOS;
using ProjectFiado.Mapper;
using ProjectFiado.Models;
using ProjectFiado.Repository.Interfaces;
using ProjectFiado.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFiado.Services
{
    public class ProductService
    {
        private readonly IProduct _productRepository;
        private readonly ProductMapper _mapper;

        public ProductService(IProduct productRepository, ProductMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ResponseProductDTO> CreateProduct(RequestProductDTO requestProductDTO)
        {
            ProductValidate.Validate(requestProductDTO);

            var productModel = _mapper.RequestDtoToModel(requestProductDTO);
            var createdProduct = await _productRepository.CreateProduct(productModel);
            var responseProductDTO = _mapper.ProductModelToResponse(createdProduct);

            return responseProductDTO;
        }

        public async Task<ResponseProductDTO> GetById(int id)
        {
            var productModelId = await _productRepository.GetById(id);

            if (productModelId == null)
            {
                throw new KeyNotFoundException("Produto não encontrado");
            }

            ResponseProductDTO response = _mapper.ProductModelToResponse(productModelId);
            return response;
        }

        public async Task<ResponseProductDTO> GetNameProduct(string name)
        {
            var productModelName = await _productRepository.GetNameProductAsync(name);

            if (productModelName == null)
            {
                throw new KeyNotFoundException("Produto não encontrado");
            }

            ResponseProductDTO response = _mapper.ProductModelToResponse(productModelName);
            return response;
        }

        public async Task<IEnumerable<ResponseProductDTO>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            var responseProducts = products.Select(product => _mapper.ProductModelToResponse(product));

            return responseProducts;
        }

        public async Task<ResponseProductDTO> UpdateProduct(int id, RequestProductDTO updateRequestProduct)
        {
            ProductValidate.Validate(updateRequestProduct);

            var existingProduct = await _productRepository.GetById(id);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException("Produto não encontrado.");
            }

            var updatedProductModel = _mapper.RequestDtoToModel(updateRequestProduct);

            // Atualiza as propriedades do produto existente
            existingProduct.Name = updatedProductModel.Name;
            existingProduct.Price = updatedProductModel.Price;
            existingProduct.Description = updatedProductModel.Description;
            existingProduct.Brand = updatedProductModel.Brand;

            await _productRepository.UpdateProduct(id, existingProduct);

            var responseProduct = _mapper.ProductModelToResponse(existingProduct);
            return responseProduct;
        }
    }
}
