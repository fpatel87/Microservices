namespace ProductMicroservice.ApplicationCore.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public int Qty { get; set; }

        public string? ProductImage { get; set; }

        public string SKU { get; set; } = string.Empty;

        // Category
        public Category? Category { get; set; }

        // Product variation values
        public ICollection<ProductVariationValue> ProductVariationValues { get; set; }
            = new List<ProductVariationValue>();
    }
}