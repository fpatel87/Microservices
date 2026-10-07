namespace ProductMicroservice.ApplicationCore.Models
{
    public class CategoryVariation
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string VariationName { get; set; } = string.Empty;

        // Category
        public Category? Category { get; set; }

        // Variation values
        public ICollection<VariationValue> VariationValues { get; set; }
            = new List<VariationValue>();
    }
}