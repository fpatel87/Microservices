namespace ProductMicroservice.ApplicationCore.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int? ParentCategoryId { get; set; }

        // Parent category
        public Category? ParentCategory { get; set; }

        // Child categories
        public ICollection<Category> ChildCategories { get; set; }
            = new List<Category>();

        // Category variations
        public ICollection<CategoryVariation> CategoryVariations { get; set; }
            = new List<CategoryVariation>();

        // Products
        public ICollection<Product> Products { get; set; }
            = new List<Product>();
    }
}