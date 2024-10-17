using ProjectFiado.Models;

namespace ProjectFiado.Repository.Interfaces
{
    public interface IProduct
    {
        Task<ProductModel> CreateProduct(ProductModel productModel);
        Task<ProductModel> UpdateProduct(int id, ProductModel productModel);
        Task<IEnumerable<ProductModel>> GetAllProducts();
        Task<ProductModel> GetById(int id);
        Task<ProductModel> GetNameProductAsync(string name);

    }
}
