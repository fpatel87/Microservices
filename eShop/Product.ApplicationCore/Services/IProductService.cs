using ProductMicroservice.ApplicationCore.Models;

namespace ProductMicroservice.ApplicationCore.Services
{
    public interface IProductService
    {
        Task<(IEnumerable<Product> Products, int TotalCount)> GetListProducts(
            int pageNumber,
            int pageSize,
            int? categoryId);

        Task<Product?> GetProductById(int id);

        Task<Product> Save(Product product);

        Task<Product?> Update(Product product);

        Task<bool> InActive(int id);

        Task<IEnumerable<Product>> GetProductByCategoryId(
            int categoryId);

        Task<IEnumerable<Product>> GetProductByName(
            string name);

        Task<bool> DeleteProduct(int id);
    }
}