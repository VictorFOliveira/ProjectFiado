using ProjectFiado.Domain.Models;
using ProjectFiado.Models;

namespace ProjectFiado.Repository.Interfaces
{
    public interface IStock
    { 
        // pensando aqui em outro metodo para implantar 

        Task<StockModel> AddProduct(int id, StockModel stockModel);
        Task<StockModel> GetById(int id);
        Task<bool> RemoveStock(int id);
        Task<StockModel> AlterProduct(int id, int quantity);

    }
}
