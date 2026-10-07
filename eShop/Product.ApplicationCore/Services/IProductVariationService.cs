using ProductMicroservice.ApplicationCore.Models;

namespace ProductMicroservice.ApplicationCore.Services
{
    public interface IProductVariationService
    {
        Task<ProductVariationValue> Save(
            ProductVariationValue productVariationValue);

        Task<IEnumerable<ProductVariationValue>> GetProductVariation(
            int productId);
    }
}