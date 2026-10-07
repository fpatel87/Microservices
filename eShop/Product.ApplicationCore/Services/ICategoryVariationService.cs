using ProductMicroservice.ApplicationCore.Models;

namespace ProductMicroservice.ApplicationCore.Services
{
    public interface ICategoryVariationService
    {
        Task<IEnumerable<CategoryVariation>> GetAll();

        Task<CategoryVariation?> GetCategoryVariationById(int id);

        Task<IEnumerable<CategoryVariation>> GetCategoryVariationByCategoryId(int categoryId);

        Task<CategoryVariation> Save(CategoryVariation categoryVariation);

        Task<bool> Delete(int id);
    }
}