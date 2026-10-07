using ProductMicroservice.ApplicationCore.Models;
using ProductMicroservice.ApplicationCore.Repositories;

namespace ProductMicroservice.ApplicationCore.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return await _categoryRepository.GetAllCategory();
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            return await _categoryRepository.GetCategoryById(id);
        }

        public async Task<IEnumerable<Category>> GetCategoryByParentCategoryId(
            int parentCategoryId)
        {
            return await _categoryRepository
                .GetCategoryByParentCategoryId(parentCategoryId);
        }

        public async Task<Category> SaveCategory(Category category)
        {
            return await _categoryRepository.SaveCategory(category);
        }

        public async Task<bool> Delete(int id)
        {
            return await _categoryRepository.Delete(id);
        }
    }
}