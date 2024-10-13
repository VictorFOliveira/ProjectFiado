using ProjectFiado.Models;
using ProjectFiado.Models.DTOs;

namespace ProjectFiado.Mapper
{
    public class ProductMapper
    {
        public ProductModel RequestDtoToModel(RequestProductDTO requestProductDTO)
        {
            return new ProductModel
            {
                Name = requestProductDTO.Name,
                Price = requestProductDTO.Price,
                Brand = requestProductDTO.Brand,
                Description = requestProductDTO.Description,
            };
        }

        public ResponseProductDTO ProductModelToResponse(ProductModel productModel)
        {
            return new ResponseProductDTO
            {
                Name = productModel.Name,
                Price = productModel.Price,
                Brand = productModel.Brand,
                Description = productModel.Description,
            };
        }
    }
}
