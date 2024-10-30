using System.ComponentModel.DataAnnotations;

namespace ProjectFiado.Domain.Models.DTOs.StockDTOS
{
    public class RequestStockDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateOnly Validate { get; set; }
    }
}
