using Microsoft.EntityFrameworkCore;
using ProductMicroservice.ApplicationCore.Models;
using ProductMicroservice.ApplicationCore.Repositories;
using ProductMicroservice.Infrastructure.Data;

namespace ProductMicroservice.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductDbContext _context;

        public CategoryRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await _context.Categories
                .Include(c => c.ParentCategory)
                .ToListAsync();
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            return await _context.Categories
                .Include(c => c.ParentCategory)
                .Include(c => c.ChildCategories)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Category>> GetCategoryByParentCategoryId(
            int parentCategoryId)
        {
            return await _context.Categories
                .Where(c => c.ParentCategoryId == parentCategoryId)
                .ToListAsync();
        }

        public async Task<Category> SaveCategory(Category category)
        {
            _context.Categories.Add(category);

            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<bool> Delete(int id)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return false;
            }

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}