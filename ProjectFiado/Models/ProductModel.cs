using System.ComponentModel.DataAnnotations;

namespace ProjectFiado.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public string Brand { get; set; }
    }
}
