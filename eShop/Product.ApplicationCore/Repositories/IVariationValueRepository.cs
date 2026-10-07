using ProductMicroservice.ApplicationCore.Models;

namespace ProductMicroservice.ApplicationCore.Repositories
{
    public interface IVariationValueRepository
    {
        Task<VariationValue> Save(VariationValue variationValue);

        Task<IEnumerable<VariationValue>> GetVariationId(int variationId);
    }
}