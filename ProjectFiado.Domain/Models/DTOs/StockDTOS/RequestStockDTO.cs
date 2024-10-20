﻿using System.ComponentModel.DataAnnotations;

namespace ProjectFiado.Domain.Models.DTOs.StockDTOS
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
