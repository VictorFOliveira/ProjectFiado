using Microsoft.EntityFrameworkCore;
using ProjectFiado.Data;
using ProjectFiado.Mapper;
using ProjectFiado.Models;
using ProjectFiado.Models.DTOs;
using ProjectFiado.Repository.Interfaces;
using ProjectFiado.Validation;

namespace ProjectFiado.Repository
{
    public class ProductRepository : IProduct
    {

        private readonly FiadoDBContext _dbContext;
        private readonly ProductMapper _mapper;

        public ProductRepository(FiadoDBContext dBContext)
        {
            _dbContext = dBContext;
            _mapper = new ProductMapper();
        }

        public async Task<ResponseProductDTO> CreateProduct(RequestProductDTO requestProductDTO)
        {

            ProductValidate.Validate(requestProductDTO);

            ProductModel productModel = _mapper.RequestDtoToModel(requestProductDTO);

            await _dbContext.products.AddAsync(productModel);

            await _dbContext.SaveChangesAsync();

            ResponseProductDTO responseProductDTO = _mapper.ProductModelToResponse(productModel);

            return responseProductDTO;

        }

        public async Task<IEnumerable<ResponseProductDTO>> GetAllProducts()
        {
            var products = await _dbContext.products.ToListAsync();
            return products.Select(product => _mapper.ProductModelToResponse(product));
        }



        public async Task<ResponseProductDTO> GetById(int id)
        {
            ProductModel productModelId = await _dbContext.products.FirstOrDefaultAsync(x => x.Id == id);
            if(productModelId == null)
            {
                throw new KeyNotFoundException("não encontrado");

            }
            ResponseProductDTO responseProductDTO = _mapper.ProductModelToResponse(productModelId);
            return responseProductDTO;
        }

        public async Task<ProductModel> GetNameProductAsync(string name)
        {
            return await _dbContext.products.FirstOrDefaultAsync(x => x.Name == name);

        }

        public async Task<ResponseProductDTO> UpdateProduct(int id, RequestProductDTO requestProductDTO)
        {
            ProductModel  updateProduct = await _dbContext.products.FirstOrDefaultAsync(x=>x.Id == id);
            if(updateProduct == null)
            {
                throw new KeyNotFoundException("Erro");
            }

            updateProduct.Price = requestProductDTO.Price;
            updateProduct.Description = requestProductDTO.Description;
            updateProduct.Name = requestProductDTO.Name;
            updateProduct.Brand = requestProductDTO.Brand;

            await _dbContext.SaveChangesAsync();

            return _mapper.ProductModelToResponse(updateProduct);
            
        }
    }
}
