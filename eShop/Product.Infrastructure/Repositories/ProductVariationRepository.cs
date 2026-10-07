using Microsoft.EntityFrameworkCore;
using ProductMicroservice.ApplicationCore.Models;
using ProductMicroservice.ApplicationCore.Repositories;
using ProductMicroservice.Infrastructure.Data;

namespace ProductMicroservice.Infrastructure.Repositories
{
    public class ProductVariationRepository : IProductVariationRepository
    {
        private readonly ProductDbContext _context;

        public ProductVariationRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<ProductVariationValue> Save(
            ProductVariationValue productVariationValue)
        {
            _context.ProductVariationValues.Add(productVariationValue);

            await _context.SaveChangesAsync();

            return productVariationValue;
        }

        public async Task<IEnumerable<ProductVariationValue>>
            GetProductVariation(int productId)
        {
            return await _context.ProductVariationValues
                .Where(pv => pv.ProductId == productId)
                .Include(pv => pv.VariationValue)
                    .ThenInclude(v => v.CategoryVariation)
                .ToListAsync();
        }
    }
}