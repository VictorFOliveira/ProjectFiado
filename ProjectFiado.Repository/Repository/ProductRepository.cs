using Microsoft.EntityFrameworkCore;
using ProjectFiado.Data;
using ProjectFiado.Models;
using ProjectFiado.Repository.Interfaces;

namespace ProjectFiado.Repository
{
    public class ProductRepository : IProduct
    {
        private readonly FiadoDBContext _dbContext;

        public ProductRepository(FiadoDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<ProductModel> CreateProduct(ProductModel productModel)
        {
            await _dbContext.products.AddAsync(productModel);
            await _dbContext.SaveChangesAsync();
            return productModel;
        }

        public async Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            return await _dbContext.products.ToListAsync();
        }

        public async Task<ProductModel> GetById(int id)
        {
            var productModel = await _dbContext.products.FirstOrDefaultAsync(x => x.Id == id);
            if (productModel == null)
            {
                throw new KeyNotFoundException("Produto não encontrado");
            }
            return productModel;
        }

        public async Task<ProductModel> UpdateProduct(int id, ProductModel updatedProduct)
        {
            var existingProduct = await _dbContext.products.FirstOrDefaultAsync(x => x.Id == id);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException("Produto não encontrado");
            }

            existingProduct.Price = updatedProduct.Price;
            existingProduct.Description = updatedProduct.Description;
            existingProduct.Name = updatedProduct.Name;
            existingProduct.Brand = updatedProduct.Brand;

            await _dbContext.SaveChangesAsync();

            return existingProduct;
        }
    }
}
