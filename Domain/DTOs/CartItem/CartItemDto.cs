using System;
using System.Collections.Generic;
using System.Text;
namespace Domain.DTOs.CartItem
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public int Quantity { get; set; }
    }
}