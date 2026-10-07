using Microsoft.EntityFrameworkCore;
using ShippingMicroservice.ApplicationCore.Entities;

namespace ShippingMicroservice.Infrastructure.Data
{
    public class ShippingDbContext : DbContext
    {
        public ShippingDbContext(DbContextOptions<ShippingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Shipper> Shippers { get; set; }

        public DbSet<ShipperRegion> ShipperRegions { get; set; }

        public DbSet<ShippingDetails> ShippingDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Region
            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("Region");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id)
                    .UseIdentityColumn(100, 1);

                entity.Property(x => x.Name)
                    .HasMaxLength(100)
                    .IsRequired();
            });

            // Shipper
            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.ToTable("Shipper");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.Name)
                    .HasMaxLength(150)
                    .IsRequired();

                entity.Property(x => x.EmailId)
                    .HasMaxLength(255);

                entity.Property(x => x.Phone)
                    .HasMaxLength(20);

                entity.Property(x => x.ContactPerson)
                    .HasColumnName("Contact_Person")
                    .HasMaxLength(150);
            });

            // Shipper_Region
            modelBuilder.Entity<ShipperRegion>(entity =>
            {
                entity.ToTable("Shipper_Region");

                entity.HasKey(x => new
                {
                    x.RegionId,
                    x.ShipperId
                });

                entity.Property(x => x.RegionId)
                    .HasColumnName("Region_Id");

                entity.Property(x => x.ShipperId)
                    .HasColumnName("Shipper_Id");

                entity.Property(x => x.Active)
                    .HasDefaultValue(true);

                entity.HasOne(x => x.Region)
                    .WithMany(x => x.ShipperRegions)
                    .HasForeignKey(x => x.RegionId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(x => x.Shipper)
                    .WithMany(x => x.ShipperRegions)
                    .HasForeignKey(x => x.ShipperId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Shipping_Details
            modelBuilder.Entity<ShippingDetails>(entity =>
            {
                entity.ToTable("Shipping_Details");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.OrderId)
                    .HasColumnName("Order_Id")
                    .IsRequired();

                entity.Property(x => x.ShipperId)
                    .HasColumnName("Shipper_Id")
                    .IsRequired();

                entity.Property(x => x.ShippingStatus)
                    .HasColumnName("Shipping_Status")
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(x => x.TrackingNumber)
                    .HasColumnName("Tracking_Number")
                    .HasMaxLength(100);

                entity.HasOne(x => x.Shipper)
                    .WithMany(x => x.ShippingDetails)
                    .HasForeignKey(x => x.ShipperId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}