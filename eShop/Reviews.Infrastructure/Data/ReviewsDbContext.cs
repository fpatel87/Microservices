using Microsoft.EntityFrameworkCore;
using ReviewsMicroservice.ApplicationCore.Models;

namespace ReviewsMicroservice.Infrastructure.Data
{
    public class ReviewsDbContext : DbContext
    {
        public ReviewsDbContext(DbContextOptions<ReviewsDbContext> options)
            : base(options)
        {
        }

        public DbSet<CustomerReview> CustomerReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustomerReview>(entity =>
            {
                entity.ToTable("Customer_Review");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.CustomerId)
                    .HasColumnName("Customer_Id");

                entity.Property(x => x.CustomerName)
                    .HasColumnName("Customer_Name")
                    .HasMaxLength(250)
                    .IsRequired();

                entity.Property(x => x.OrderId)
                    .HasColumnName("Order_Id");

                entity.Property(x => x.OrderDate)
                    .HasColumnName("Order_Date")
                    .HasColumnType("date")
                    .IsRequired();

                entity.Property(x => x.ProductId)
                    .HasColumnName("Product_Id");

                entity.Property(x => x.ProductName)
                    .HasColumnName("Product_Name")
                    .HasMaxLength(253)
                    .IsRequired();

                entity.Property(x => x.RatingValue)
                    .HasColumnName("Rating_Value")
                    .IsRequired();

                entity.Property(x => x.Comment)
                    .HasColumnName("Comment")
                    .HasMaxLength(500)
                    .IsRequired();

                entity.Property(x => x.ReviewDate)
                    .HasColumnName("Review_Date")
                    .HasColumnType("date")
                    .IsRequired();

                entity.Property(x => x.Status)
                    .HasColumnName("Status")
                    .HasMaxLength(20)
                    .IsRequired()
                    .HasDefaultValue("Pending");
            });
        }
    }
}