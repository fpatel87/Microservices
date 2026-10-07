using Microsoft.EntityFrameworkCore;
using OrderMicroservice.ApplicationCore.Entities;

namespace OrderMicroservice.Infrastructure.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public DbSet<OrderMicroservice.ApplicationCore.Entities.Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PaymentType>()
                .ToTable("Payment_Type");

            modelBuilder.Entity<PaymentMethod>()
                .ToTable("Payment_Method");

            modelBuilder.Entity<Customer>()
                .ToTable("Customer");

            modelBuilder.Entity<Address>()
                .ToTable("Address");

            modelBuilder.Entity<UserAddress>()
                .ToTable("User_Address");

            modelBuilder.Entity<ShoppingCart>()
                .ToTable("Shopping_Cart");

            modelBuilder.Entity<ShoppingCartItem>()
                .ToTable("Shopping_Cart_Item");

            modelBuilder.Entity<OrderMicroservice.ApplicationCore.Entities.Order>()
                .ToTable("Order");

            modelBuilder.Entity<OrderDetail>()
                .ToTable("Order_Details");

            // Payment relationships
            modelBuilder.Entity<PaymentMethod>()
                .HasOne(p => p.PaymentType)
                .WithMany(p => p.PaymentMethods)
                .HasForeignKey(p => p.Payment_Type_Id)
                .OnDelete(DeleteBehavior.Cascade);

            // Customer and Address relationships
            modelBuilder.Entity<UserAddress>()
                .HasOne(ua => ua.Customer)
                .WithMany(c => c.UserAddresses)
                .HasForeignKey(ua => ua.Customer_Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserAddress>()
                .HasOne(ua => ua.Address)
                .WithMany(a => a.UserAddresses)
                .HasForeignKey(ua => ua.Address_Id)
                .OnDelete(DeleteBehavior.Cascade);

            // Shopping Cart relationships
            modelBuilder.Entity<ShoppingCart>()
                .HasOne(sc => sc.Customer)
                .WithMany(c => c.ShoppingCarts)
                .HasForeignKey(sc => sc.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ShoppingCartItem>()
                .HasOne(sci => sci.ShoppingCart)
                .WithMany(sc => sc.ShoppingCartItems)
                .HasForeignKey(sci => sci.Cart_Id)
                .OnDelete(DeleteBehavior.Cascade);

            // Order relationships
            modelBuilder.Entity<OrderMicroservice.ApplicationCore.Entities.Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.Order_Id)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}