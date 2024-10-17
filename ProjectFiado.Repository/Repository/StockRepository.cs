using Microsoft.EntityFrameworkCore;
using ProjectFiado.Data;
using ProjectFiado.Models;
using ProjectFiado.Repository.Interfaces;

namespace ProjectFiado.Repository
{
    public class StockRepository : IStock
    {
        private readonly FiadoDBContext _dbContext;

        public StockRepository(FiadoDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<StockModel> AddProduct(StockModel stockModel)
        {
            await _dbContext.stocks.AddAsync(stockModel);
            await _dbContext.SaveChangesAsync();
            return stockModel;
        }

        public async Task<StockModel> AlterValidateProduct(int id, StockModel updatedStock)
        {
            var stockModel = await _dbContext.stocks.FirstOrDefaultAsync(x => x.ProductId == id);

            if (stockModel == null)
            {
                throw new KeyNotFoundException("Produto não encontrado.");
            }

            stockModel.Quantity = updatedStock.Quantity;
            stockModel.Validate = updatedStock.Validate;

            await _dbContext.SaveChangesAsync();

            return stockModel;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var stockModel = await _dbContext.stocks.FirstOrDefaultAsync(x => x.ProductId == id);

            if (stockModel == null)
            {
                throw new KeyNotFoundException("Produto não encontrado.");
            }

            _dbContext.stocks.Remove(stockModel);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<StockModel> GetProductById(int id)
        {
            var stockModel = await _dbContext.stocks.FirstOrDefaultAsync(x => x.ProductId == id);

            if (stockModel == null)
            {
                throw new KeyNotFoundException("Produto não encontrado.");
            }

            return stockModel;
        }
    }
}
