using Microsoft.EntityFrameworkCore;

using CategoryModel =
    ProductMicroservice.ApplicationCore.Models.Category;

using CategoryVariationModel =
    ProductMicroservice.ApplicationCore.Models.CategoryVariation;

using VariationValueModel =
    ProductMicroservice.ApplicationCore.Models.VariationValue;

using ProductModel =
    ProductMicroservice.ApplicationCore.Models.Product;

using ProductVariationValueModel =
    ProductMicroservice.ApplicationCore.Models.ProductVariationValue;

namespace ProductMicroservice.Infrastructure.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(
            DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }

        public DbSet<CategoryModel> Categories { get; set; }

        public DbSet<CategoryVariationModel> CategoryVariations { get; set; }

        public DbSet<VariationValueModel> VariationValues { get; set; }

        public DbSet<ProductModel> Products { get; set; }

        public DbSet<ProductVariationValueModel>
            ProductVariationValues
        { get; set; }


        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<CategoryModel>()
                .ToTable("Product_Category");

            modelBuilder.Entity<CategoryModel>()
                .Property(c => c.Id)
                .HasColumnName("id");

            modelBuilder.Entity<CategoryModel>()
                .Property(c => c.Name)
                .HasColumnName("Name");

            modelBuilder.Entity<CategoryModel>()
                .Property(c => c.ParentCategoryId)
                .HasColumnName("Parent_Category_Id");

            modelBuilder.Entity<CategoryModel>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.ChildCategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // CATEGORY VARIATION
            // ==========================================

            modelBuilder.Entity<CategoryVariationModel>()
                .ToTable("Category_Variation");

            modelBuilder.Entity<CategoryVariationModel>()
                .Property(cv => cv.Id)
                .HasColumnName("id");

            modelBuilder.Entity<CategoryVariationModel>()
                .Property(cv => cv.CategoryId)
                .HasColumnName("Category_Id");

            modelBuilder.Entity<CategoryVariationModel>()
                .Property(cv => cv.VariationName)
                .HasColumnName("Variation_Name");

            modelBuilder.Entity<CategoryVariationModel>()
                .HasOne(cv => cv.Category)
                .WithMany(c => c.CategoryVariations)
                .HasForeignKey(cv => cv.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);


            // ==========================================
            // VARIATION VALUE
            // ==========================================

            modelBuilder.Entity<VariationValueModel>()
                .ToTable("Variation_Value");

            modelBuilder.Entity<VariationValueModel>()
                .Property(v => v.Id)
                .HasColumnName("id");

            modelBuilder.Entity<VariationValueModel>()
                .Property(v => v.VariationId)
                .HasColumnName("variation_id");

            modelBuilder.Entity<VariationValueModel>()
                .Property(v => v.Value)
                .HasColumnName("value");

            modelBuilder.Entity<VariationValueModel>()
                .HasOne(v => v.CategoryVariation)
                .WithMany(cv => cv.VariationValues)
                .HasForeignKey(v => v.VariationId)
                .OnDelete(DeleteBehavior.Cascade);


            // ==========================================
            // PRODUCT
            // ==========================================

            modelBuilder.Entity<ProductModel>()
                .ToTable("Product");

            modelBuilder.Entity<ProductModel>()
                .Property(p => p.Id)
                .HasColumnName("id");

            modelBuilder.Entity<ProductModel>()
                .Property(p => p.Name)
                .HasColumnName("Name");

            modelBuilder.Entity<ProductModel>()
                .Property(p => p.Description)
                .HasColumnName("Description");

            modelBuilder.Entity<ProductModel>()
                .Property(p => p.CategoryId)
                .HasColumnName("CategoryId");

            modelBuilder.Entity<ProductModel>()
                .Property(p => p.Price)
                .HasColumnName("Price")
                .HasPrecision(18, 2);

            modelBuilder.Entity<ProductModel>()
                .Property(p => p.Qty)
                .HasColumnName("Qty");

            modelBuilder.Entity<ProductModel>()
                .Property(p => p.ProductImage)
                .HasColumnName("Product_Image");

            modelBuilder.Entity<ProductModel>()
                .Property(p => p.SKU)
                .HasColumnName("SKU")
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<ProductModel>()
                .HasIndex(p => p.SKU)
                .IsUnique();

            modelBuilder.Entity<ProductModel>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);


            // ==========================================
            // PRODUCT VARIATION VALUE
            // ==========================================

            modelBuilder.Entity<ProductVariationValueModel>()
                .ToTable("Product_variation_value");

            modelBuilder.Entity<ProductVariationValueModel>()
                .HasKey(pv => new
                {
                    pv.ProductId,
                    pv.VariationValueId
                });

            modelBuilder.Entity<ProductVariationValueModel>()
                .Property(pv => pv.ProductId)
                .HasColumnName("Product_Id");

            modelBuilder.Entity<ProductVariationValueModel>()
                .Property(pv => pv.VariationValueId)
                .HasColumnName("Variation_value_id");

            modelBuilder.Entity<ProductVariationValueModel>()
                .HasOne(pv => pv.Product)
                .WithMany(p => p.ProductVariationValues)
                .HasForeignKey(pv => pv.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductVariationValueModel>()
                .HasOne(pv => pv.VariationValue)
                .WithMany(v => v.ProductVariationValues)
                .HasForeignKey(pv => pv.VariationValueId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

