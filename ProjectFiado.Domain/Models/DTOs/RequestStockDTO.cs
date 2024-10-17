using System.ComponentModel.DataAnnotations;

namespace ProjectFiado.Models.DTOs
{
    public class RequestStockDTO
    {
        [Required]
        public int ProductId { get; set; }
        [Required]

        public int Quantity { get; set; }
        [Required]

        public DateOnly Validate { get; set; }
    }
}
