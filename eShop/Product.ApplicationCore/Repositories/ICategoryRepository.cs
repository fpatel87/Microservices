using ProductMicroservice.ApplicationCore.Models;

namespace ProductMicroservice.ApplicationCore.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategory();

        Task<Category?> GetCategoryById(int id);

        Task<IEnumerable<Category>> GetCategoryByParentCategoryId(int parentCategoryId);

        Task<Category> SaveCategory(Category category);

        Task<bool> Delete(int id);
    }
}