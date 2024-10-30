using ProjectFiado.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectFiado.Domain.Models
{
    public class StockModel
    {
        [Key]
        public int Id { get; set; }

        public int ProductID { get; set; }

        [ForeignKey("ProductID")] 
        public ProductModel Product { get; set; } 

        public int Quantity { get; set; }
        public DateOnly Validate { get; set; }
    }
}
