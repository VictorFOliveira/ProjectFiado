namespace ProjectFiado.Models.DTOs
{
    public class ResponseStockDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateOnly Validate { get; set; }
    }
}
