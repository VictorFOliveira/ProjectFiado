namespace ProjectFiado.Models.DTOs
{
    public class ResponseProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public string Brand { get; set; }
    }
}
