using ProjectFiado.Models;
using ProjectFiado.Models.DTOs;

namespace ProjectFiado.Repository.Interfaces
{
    public interface IStock
    { 
        // pensando aqui em outro metodo para implantar 

        Task<StockModel> AddProduct(StockModel stockModel);
        Task<bool> DeleteProduct(int id);
        Task<StockModel> GetProductById(int id);
        Task<StockModel> AlterValidateProduct(int id, StockModel stockModel);

    }
}
