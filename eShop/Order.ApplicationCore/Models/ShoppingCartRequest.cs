using OrderMicroservice.ApplicationCore.Entities;

namespace OrderMicroservice.ApplicationCore.Models
{
    public class ShoppingCartRequest
    {
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }

        public List<ShoppingCartItemRequest> Items { get; set; }
            = new List<ShoppingCartItemRequest>();
    }

    public class ShoppingCartItemRequest
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Qty { get; set; }
        public decimal Price { get; set; }
    }
}