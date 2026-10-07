using Microsoft.EntityFrameworkCore;
using ProductModel = ProductMicroservice.ApplicationCore.Models.Product;
using ProductMicroservice.ApplicationCore.Repositories;
using ProductMicroservice.Infrastructure.Data;

namespace ProductMicroservice.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<ProductModel> Products, int TotalCount)>
            GetListProducts(
                int pageNumber,
                int pageSize,
                int? categoryId)
        {
            var query = _context.Products
                .Include(p => p.Category)
                .AsQueryable();

            if (categoryId.HasValue)
            {
                query = query.Where(p =>
                    p.CategoryId == categoryId.Value);
            }

            var totalCount = await query.CountAsync();

            var products = await query
                .OrderBy(p => p.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (products, totalCount);
        }

        public async Task<ProductModel?> GetProductById(int id)
        {
            return await _context.Products
            .Include(p => p.Category)
            .Include(p => p.ProductVariationValues)
            .ThenInclude(pv => pv.VariationValue)
            .ThenInclude(v => v.CategoryVariation)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ProductModel> Save(ProductModel product)
        {
            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<ProductModel?> Update(ProductModel product)
        {
            var existingProduct = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == product.Id);

            if (existingProduct == null)
            {
                return null;
            }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.Price = product.Price;
            existingProduct.Qty = product.Qty;
            existingProduct.ProductImage = product.ProductImage;
            existingProduct.SKU = product.SKU;

            await _context.SaveChangesAsync();

            return existingProduct;
        }

        public async Task<bool> InActive(int id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return false;
            }

            product.Qty = 0;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ProductModel>> GetProductByCategoryId(
            int categoryId)
        {
            return await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductModel>> GetProductByName(
            string name)
        {
            return await _context.Products
                .Where(p => p.Name.Contains(name))
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return false;
            }

            var productVariationValues = await _context.ProductVariationValues
                .Where(pv => pv.ProductId == id)
                .ToListAsync();

            if (productVariationValues.Any())
            {
                _context.ProductVariationValues.RemoveRange(
                    productVariationValues);
            }

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}

