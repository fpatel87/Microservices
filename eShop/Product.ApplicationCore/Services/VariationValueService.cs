using ProductMicroservice.ApplicationCore.Models;
using ProductMicroservice.ApplicationCore.Repositories;

namespace ProductMicroservice.ApplicationCore.Services
{
    public class VariationValueService : IVariationValueService
    {
        private readonly IVariationValueRepository _repository;

        public VariationValueService(
            IVariationValueRepository repository)
        {
            _repository = repository;
        }

        public async Task<VariationValue> Save(
            VariationValue variationValue)
        {
            return await _repository.Save(variationValue);
        }

        public async Task<IEnumerable<VariationValue>> GetVariationId(
            int variationId)
        {
            return await _repository.GetVariationId(variationId);
        }
    }
}