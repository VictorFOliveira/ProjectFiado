using ProjectFiado.Domain.Models.DTOs.StockDTOS;

namespace ProjectFiado.Validation
{
    public class StockValidate
    {
        public static void Validate(RequestStockDTO requestStockDTO)
        {
            if (requestStockDTO == null)
            {
                throw new ArgumentNullException(nameof(requestStockDTO));
            }

            if (requestStockDTO.ProductId == null)
            {
                throw new KeyNotFoundException(nameof(requestStockDTO.ProductId));
            }

            if (requestStockDTO.Quantity <= 0)
            {
                throw new ArgumentNullException(nameof(requestStockDTO.Quantity));
            }

            if (requestStockDTO.Validate <= DateOnly.FromDateTime(DateTime.Now))
            {
                throw new InvalidOperationException("Erro");
            }
        }
    }
}
