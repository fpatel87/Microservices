using ProductMicroservice.ApplicationCore.Models;

namespace ProductMicroservice.ApplicationCore.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategory();

        Task<Category?> GetCategoryById(int id);

        Task<IEnumerable<Category>> GetCategoryByParentCategoryId(int parentCategoryId);

        Task<Category> SaveCategory(Category category);

        Task<bool> Delete(int id);
    }
}