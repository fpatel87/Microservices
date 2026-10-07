using ProductMicroservice.ApplicationCore.Models;
using ProductMicroservice.ApplicationCore.Repositories;

namespace ProductMicroservice.ApplicationCore.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<(IEnumerable<Product> Products, int TotalCount)> GetListProducts(
            int pageNumber,
            int pageSize,
            int? categoryId)
        {
            return await _productRepository.GetListProducts(
                pageNumber,
                pageSize,
                categoryId);
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _productRepository.GetProductById(id);
        }

        public async Task<Product> Save(Product product)
        {
            return await _productRepository.Save(product);
        }

        public async Task<Product?> Update(Product product)
        {
            return await _productRepository.Update(product);
        }

        public async Task<bool> InActive(int id)
        {
            return await _productRepository.InActive(id);
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryId(int categoryId)
        {
            return await _productRepository.GetProductByCategoryId(categoryId);
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            return await _productRepository.GetProductByName(name);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await _productRepository.DeleteProduct(id);
        }
    }
}