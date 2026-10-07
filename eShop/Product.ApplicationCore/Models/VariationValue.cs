namespace ProductMicroservice.ApplicationCore.Models
{
    public class VariationValue
    {
        public int Id { get; set; }

        public int VariationId { get; set; }

        public string Value { get; set; } = string.Empty;

        // Category variation
        public CategoryVariation? CategoryVariation { get; set; }

        // Products using this value
        public ICollection<ProductVariationValue> ProductVariationValues { get; set; }
            = new List<ProductVariationValue>();
    }
}