using Microsoft.EntityFrameworkCore;
using ProductMicroservice.ApplicationCore.Models;
using ProductMicroservice.ApplicationCore.Repositories;
using ProductMicroservice.Infrastructure.Data;

namespace ProductMicroservice.Infrastructure.Repositories
{
    public class CategoryVariationRepository : ICategoryVariationRepository
    {
        private readonly ProductDbContext _context;

        public CategoryVariationRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryVariation>> GetAll()
        {
            return await _context.CategoryVariations
                .Include(cv => cv.Category)
                .Include(cv => cv.VariationValues)
                .ToListAsync();
        }

        public async Task<CategoryVariation?> GetCategoryVariationById(int id)
        {
            return await _context.CategoryVariations
                .Include(cv => cv.Category)
                .Include(cv => cv.VariationValues)
                .FirstOrDefaultAsync(cv => cv.Id == id);
        }

        public async Task<IEnumerable<CategoryVariation>>
            GetCategoryVariationByCategoryId(int categoryId)
        {
            return await _context.CategoryVariations
                .Where(cv => cv.CategoryId == categoryId)
                .Include(cv => cv.VariationValues)
                .ToListAsync();
        }

        public async Task<CategoryVariation> Save(
            CategoryVariation categoryVariation)
        {
            _context.CategoryVariations.Add(categoryVariation);

            await _context.SaveChangesAsync();

            return categoryVariation;
        }

        public async Task<bool> Delete(int id)
        {
            var variation = await _context.CategoryVariations
                .FirstOrDefaultAsync(cv => cv.Id == id);

            if (variation == null)
            {
                return false;
            }

            _context.CategoryVariations.Remove(variation);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}