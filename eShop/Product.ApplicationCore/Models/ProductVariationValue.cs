namespace ProductMicroservice.ApplicationCore.Models
{
    public class ProductVariationValue
    {
        public int ProductId { get; set; }

        public int VariationValueId { get; set; }

        // Product
        public Product? Product { get; set; }

        // Variation value
        public VariationValue? VariationValue { get; set; }
    }
}