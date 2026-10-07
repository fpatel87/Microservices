using Microsoft.AspNetCore.Mvc;
using ProductModel = ProductMicroservice.ApplicationCore.Models.Product;
using ProductMicroservice.ApplicationCore.Services;

namespace ProductMicroservice.API.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetListProducts")]
        public async Task<IActionResult> GetListProducts(
            int pageNumber = 1,
            int pageSize = 10,
            int? categoryId = null)
        {
            var result = await _productService.GetListProducts(
                pageNumber,
                pageSize,
                categoryId);

            return Ok(new
            {
                pageNumber,
                pageSize,
                totalCount = result.TotalCount,
                products = result.Products
            });
        }

        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _productService.GetProductById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(
            [FromBody] ProductModel product)
        {
            var result = await _productService.Save(product);

            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(
            [FromBody] ProductModel product)
        {
            var result = await _productService.Update(product);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("InActive")]
        public async Task<IActionResult> InActive(int id)
        {
            var result = await _productService.InActive(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Product marked as inactive successfully."
            });
        }

        [HttpGet("GetProductByCategoryId")]
        public async Task<IActionResult> GetProductByCategoryId(
            int categoryId)
        {
            var result = await _productService
                .GetProductByCategoryId(categoryId);

            return Ok(result);
        }

        [HttpGet("GetProductByName")]
        public async Task<IActionResult> GetProductByName(string name)
        {
            var result = await _productService.GetProductByName(name);

            return Ok(result);
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProduct(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Product deleted successfully."
            });
        }
    }
}