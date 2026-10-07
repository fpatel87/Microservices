using ProductMicroservice.ApplicationCore.Models;
using ProductMicroservice.ApplicationCore.Repositories;

namespace ProductMicroservice.ApplicationCore.Services
{
    public class CategoryVariationService : ICategoryVariationService
    {
        private readonly ICategoryVariationRepository _repository;

        public CategoryVariationService(
            ICategoryVariationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CategoryVariation>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<CategoryVariation?> GetCategoryVariationById(int id)
        {
            return await _repository.GetCategoryVariationById(id);
        }

        public async Task<IEnumerable<CategoryVariation>>
            GetCategoryVariationByCategoryId(int categoryId)
        {
            return await _repository
                .GetCategoryVariationByCategoryId(categoryId);
        }

        public async Task<CategoryVariation> Save(
            CategoryVariation categoryVariation)
        {
            return await _repository.Save(categoryVariation);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }
    }
}