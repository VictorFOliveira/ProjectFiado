using ProjectFiado.Domain.Models.DTOs.ProductDTOS;
using ProjectFiado.Models;

namespace ProjectFiado.Domain.Models.DTOs.StockDTOS
{
    public class ResponseStockDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateOnly Validate { get; set; }
    }
}
