using ProjectFiado.Domain.Enum;
using ProjectFiado.Domain.Models.DTOs.ProductDTOS;
using ProjectFiado.Exceptions;
using ProjectFiado.Mapper;
using ProjectFiado.Repository.Interfaces;
using ProjectFiado.Validation;
using Serilog;

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
            Log.Information("Product created successfully");
            return responseProductDTO;
        }

        public async Task<ResponseProductDTO> GetById(int id)
        {
            var productModelId = await _productRepository.GetById(id);

            if (productModelId == null)
            {
                Log.Warning(ProductErrorMessagesWrapper.ProductNotFound);
                throw new ProductExceptions(ProductErrorCode.ProductNotFound, ProductErrorMessagesWrapper.ProductNotFound);
            }

            ResponseProductDTO response = _mapper.ProductModelToResponse(productModelId);
            return response;
        }

        public async Task<IEnumerable<ResponseProductDTO>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            if(products == null)
            {
                Log.Warning(ProductErrorMessagesWrapper.ProductsNotFoundList);
                return Enumerable.Empty<ResponseProductDTO>();
            }
            var responseProducts = products.Select(product => _mapper.ProductModelToResponse(product));

            Log.Information("Products retrieved sucessfully");

            return responseProducts;
        }

        public async Task<ResponseProductDTO> UpdateProduct(int id, RequestProductDTO updateRequestProduct)
        {
            ProductValidate.Validate(updateRequestProduct);

            var existingProduct = await _productRepository.GetById(id);
            if (existingProduct == null)
            {
                Log.Warning(ProductErrorMessagesWrapper.ProductNotFound);
                throw new ProductExceptions(ProductErrorCode.ProductNotFound, ProductErrorMessagesWrapper.ProductNotFound);
            }

            var updatedProductModel = _mapper.RequestDtoToModel(updateRequestProduct);

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
