namespace ECommerceAPI.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string Description { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        // Navigation Properties
        public Category Category { get; set; } = null!;

        public ICollection<CartItem> CartItems { get; set; }
            = new List<CartItem>();

    }
}
