using Microsoft.EntityFrameworkCore;
using ProductMicroservice.ApplicationCore.Models;
using ProductMicroservice.ApplicationCore.Repositories;
using ProductMicroservice.Infrastructure.Data;

namespace ProductMicroservice.Infrastructure.Repositories
{
    public class VariationValueRepository : IVariationValueRepository
    {
        private readonly ProductDbContext _context;

        public VariationValueRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<VariationValue> Save(
            VariationValue variationValue)
        {
            _context.VariationValues.Add(variationValue);

            await _context.SaveChangesAsync();

            return variationValue;
        }

        public async Task<IEnumerable<VariationValue>> GetVariationId(
            int variationId)
        {
            return await _context.VariationValues
                .Where(v => v.VariationId == variationId)
                .ToListAsync();
        }
    }
}