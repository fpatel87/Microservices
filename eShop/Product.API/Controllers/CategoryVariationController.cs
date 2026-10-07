using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Models;
using ProductMicroservice.ApplicationCore.Services;

namespace ProductMicroservice.API.Controllers
{
    [Route("api/CatagoryVariation")]
    [ApiController]
    public class CategoryVariationController : ControllerBase
    {
        private readonly ICategoryVariationService _categoryVariationService;

        public CategoryVariationController(
            ICategoryVariationService categoryVariationService)
        {
            _categoryVariationService = categoryVariationService;
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(
            [FromBody] CategoryVariation categoryVariation)
        {
            var result = await _categoryVariationService.Save(
                categoryVariation);

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryVariationService.GetAll();

            return Ok(result);
        }

        [HttpGet("GetCategoryVariationById")]
        public async Task<IActionResult> GetCategoryVariationById(int id)
        {
            var result = await _categoryVariationService
                .GetCategoryVariationById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("GetCategoryVariationByCategoryId")]
        public async Task<IActionResult> GetCategoryVariationByCategoryId(
            int categoryId)
        {
            var result = await _categoryVariationService
                .GetCategoryVariationByCategoryId(categoryId);

            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryVariationService.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Category variation deleted successfully."
            });
        }
    }
}