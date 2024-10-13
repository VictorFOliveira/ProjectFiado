using ProjectFiado.Models.DTOs;

namespace ProjectFiado.Repository.Interfaces
{
    public interface IStock
    { 
        // pensando aqui em outro metodo para implantar 

        Task<ResponseStockDTO> AddProduct(RequestStockDTO requestStockDTO);
        Task<bool> DeleteProduct(int id);
        Task<ResponseStockDTO> GetProductById(int id);
        Task<ResponseStockDTO> AlterValidateProduct(int id, RequestStockDTO requestStockDTO);

    }
}
