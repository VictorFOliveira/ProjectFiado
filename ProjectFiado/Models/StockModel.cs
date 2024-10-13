using System.ComponentModel.DataAnnotations;

namespace ProjectFiado.Models
{
    public class StockModel
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateOnly Validate { get; set; }
    }
}
