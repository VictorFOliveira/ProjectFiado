﻿namespace ProjectFiado.Domain.Models.DTOs.ProductDTOS
{
    public class ResponseProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
    }
}
