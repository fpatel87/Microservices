using ProductMicroservice.ApplicationCore.Models;
using ProductMicroservice.ApplicationCore.Repositories;

namespace ProductMicroservice.ApplicationCore.Services
{
    public class ProductVariationService : IProductVariationService
    {
        private readonly IProductVariationRepository _repository;

        public ProductVariationService(
            IProductVariationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductVariationValue> Save(
            ProductVariationValue productVariationValue)
        {
            return await _repository.Save(productVariationValue);
        }

        public async Task<IEnumerable<ProductVariationValue>>
            GetProductVariation(int productId)
        {
            return await _repository.GetProductVariation(productId);
        }
    }
}