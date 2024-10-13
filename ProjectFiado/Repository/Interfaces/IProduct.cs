using ProjectFiado.Models;
using ProjectFiado.Models.DTOs;

namespace ProjectFiado.Repository.Interfaces
{
    public interface IProduct
    {
        Task<ResponseProductDTO> CreateProduct(RequestProductDTO requestProductDTO);
        Task<ResponseProductDTO> UpdateProduct(int id, RequestProductDTO requestProductDTO);
        Task<IEnumerable<ResponseProductDTO>> GetAllProducts();
        Task<ResponseProductDTO> GetById(int id);
        Task<ProductModel> GetNameProductAsync(string name);

    }
}
