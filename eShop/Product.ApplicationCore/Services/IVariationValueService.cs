using ProductMicroservice.ApplicationCore.Models;

namespace ProductMicroservice.ApplicationCore.Services
{
    public interface IVariationValueService
    {
        Task<VariationValue> Save(VariationValue variationValue);

        Task<IEnumerable<VariationValue>> GetVariationId(int variationId);
    }
}