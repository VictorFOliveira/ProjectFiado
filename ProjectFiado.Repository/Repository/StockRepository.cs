using Microsoft.EntityFrameworkCore;
using ProjectFiado.Data;
using ProjectFiado.Domain.Models;
using ProjectFiado.Models;
using ProjectFiado.Repository.Interfaces;

namespace ProjectFiado.Repository
{
    public class StockRepository : IStock
    {
        private readonly FiadoDBContext _dbContext;
        private readonly IProduct _productRepository;


        public StockRepository(FiadoDBContext dBContext, IProduct productRepository)
        {
            _dbContext = dBContext;
            _productRepository = productRepository;
        }

        public async Task<StockModel> AddProduct(int productId, StockModel stockModel)
        {
            var existingProduct = await _productRepository.GetById(productId);
            if (existingProduct == null)
            {
                throw new InvalidOperationException("Produto não cadastrado.");
            }

            stockModel.ProductID = existingProduct.Id;

            await _dbContext.stocks.AddAsync(stockModel);
            await _dbContext.SaveChangesAsync();

            return stockModel;
        }

        public async Task<StockModel> GetById(int id)
        {
            var stockModel = await _dbContext.stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (stockModel == null)
            {
                throw new KeyNotFoundException("Estoque não encontrado.");
            }
            return stockModel;
        }

        public async Task<bool> RemoveStock(int id)
        {
            var existingProductStock = await _dbContext.stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingProductStock == null)
            {
                return false;
            }

            _dbContext.stocks.Remove(existingProductStock);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<StockModel> AlterProduct(int id, int quantity)
        {
            var existingProductStock = await _dbContext.stocks.FirstOrDefaultAsync(x => x.Id == id);

            if(existingProductStock != null)
            {
                existingProductStock.Quantity += quantity;
                await _dbContext.SaveChangesAsync();
                return existingProductStock;

            }

            throw new KeyNotFoundException("Produto não encontrado");

            
        }
    }
}

