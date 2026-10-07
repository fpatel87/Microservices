using ProductMicroservice.ApplicationCore.Models;

namespace ProductMicroservice.ApplicationCore.Repositories
{
    public interface IProductVariationRepository
    {
        Task<ProductVariationValue> Save(ProductVariationValue productVariationValue);

        Task<IEnumerable<ProductVariationValue>> GetProductVariation(int productId);
    }
}