using ProjectFiado.Domain.Enum;
using ProjectFiado.Domain.Models.DTOs.ProductDTOS;
using ProjectFiado.Exceptions;
using Serilog;

namespace ProjectFiado.Validation
{
    public class ProductValidate
    {
        public static void Validate(RequestProductDTO requestProductDTO)
        {
            if (requestProductDTO == null)
            {
                Log.Error(ProductErrorMessagesWrapper.ProductEmpty);
                throw new ProductExceptions(ProductErrorCode.ProductEmpty, ProductErrorMessagesWrapper.ProductEmpty);
            }

            if (string.IsNullOrWhiteSpace(requestProductDTO.Name))
            {
                Log.Error(ProductErrorMessagesWrapper.ProductEmptyName);
                throw new ProductExceptions(ProductErrorCode.ProductEmptyName, ProductErrorMessagesWrapper.ProductEmptyName);
            }

            if (requestProductDTO.Price <= 0)
            {
                Log.Error(ProductErrorMessagesWrapper.InvalidPrice);
                throw new ProductExceptions(ProductErrorCode.ProductEmptyPrice, ProductErrorMessagesWrapper.InvalidPrice);
            }

            if (string.IsNullOrEmpty(requestProductDTO.Brand))
            {
                Log.Error(ProductErrorMessagesWrapper.ProductBrandEmpty);
                throw new ProductExceptions(ProductErrorCode.ProductEmptyBrand, ProductErrorMessagesWrapper.ProductBrandEmpty);
            }

            if (string.IsNullOrEmpty(requestProductDTO.Description))
            {
                Log.Error(ProductErrorMessagesWrapper.ProductDescriptionEmpty);
                throw new ProductExceptions(ProductErrorCode.ProductEmptyDescription, ProductErrorMessagesWrapper.ProductDescriptionEmpty);
            }
        }
    }
}

