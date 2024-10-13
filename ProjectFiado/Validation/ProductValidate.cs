using ProjectFiado.Models.DTOs;

namespace ProjectFiado.Validation
{
    public class ProductValidate
    {
        public static void Validate(RequestProductDTO requestProductDTO)
        {
            if (requestProductDTO == null)
            {
                throw new ArgumentNullException(nameof(requestProductDTO));
            }

            if (requestProductDTO.Name == null)
            {
                throw new ArgumentNullException(nameof(requestProductDTO.Name));
            }

            if (requestProductDTO.Description == null)
            {
                throw new ArgumentNullException(nameof(requestProductDTO.Description));
            }
            if (requestProductDTO.Price <= 0)
            {
                throw new ArgumentException("O preço deve ser maior que zero", nameof(requestProductDTO.Price));
            }

        }
    }
}