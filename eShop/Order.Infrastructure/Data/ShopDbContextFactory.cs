using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OrderMicroservice.Infrastructure.Data
{
    public class ShopDbContextFactory : IDesignTimeDbContextFactory<ShopDbContext>
    {
        public ShopDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ShopDbContext>();

            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=ShopDB;Trusted_Connection=True;TrustServerCertificate=True;");

            return new ShopDbContext(optionsBuilder.Options);
        }
    }
}