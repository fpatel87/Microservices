using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Models;
using ProductMicroservice.ApplicationCore.Services;

namespace ProductMicroservice.API.Controllers
{
    [Route("api/ProductVariation")]
    [ApiController]
    public class ProductVariationController : ControllerBase
    {
        private readonly IProductVariationService _productVariationService;

        public ProductVariationController(
            IProductVariationService productVariationService)
        {
            _productVariationService = productVariationService;
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(
            [FromBody] ProductVariationValue productVariationValue)
        {
            var result = await _productVariationService.Save(
                productVariationValue);

            return Ok(result);
        }

        [HttpGet("GetProductVariation")]
        public async Task<IActionResult> GetProductVariation(
            int productId)
        {
            var result = await _productVariationService
                .GetProductVariation(productId);

            return Ok(result);
        }
    }
}