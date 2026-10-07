using Microsoft.EntityFrameworkCore;
using PromotionsMicroservice.ApplicationCore.Models;

namespace PromotionsMicroservice.Infrastructure.Data
{
    public class PromotionsDbContext : DbContext
    {
        public PromotionsDbContext(DbContextOptions<PromotionsDbContext> options)
            : base(options)
        {
        }

        public DbSet<PromotionSale> PromotionSales { get; set; }

        public DbSet<PromotionDetail> PromotionDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PromotionSale>(entity =>
            {
                entity.ToTable("Promotion/Sale");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.Name)
                    .HasColumnType("varchar(100)")
                    .IsRequired();

                entity.Property(x => x.Description)
                    .HasColumnType("varchar(max)");

                entity.Property(x => x.Discount)
                    .HasColumnType("decimal(5,2)")
                    .IsRequired();

                entity.Property(x => x.StartDate)
                    .HasColumnName("Start_Date")
                    .HasColumnType("datetime2")
                    .IsRequired();

                entity.Property(x => x.EndDate)
                    .HasColumnName("End_Date")
                    .HasColumnType("datetime2")
                    .IsRequired();
            });

            modelBuilder.Entity<PromotionDetail>(entity =>
            {
                entity.ToTable("Promotion_Details");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.PromotionId)
                    .HasColumnName("Promotion_Id")
                    .IsRequired();

                entity.Property(x => x.ProductCategoryId)
                    .HasColumnName("Product_Category_Id")
                    .IsRequired();

                entity.Property(x => x.ProductCategoryName)
                    .HasColumnName("Product_Category_Name")
                    .HasColumnType("varchar(100)")
                    .IsRequired();

                entity.HasOne(x => x.Promotion)
                    .WithMany(x => x.PromotionDetails)
                    .HasForeignKey(x => x.PromotionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}