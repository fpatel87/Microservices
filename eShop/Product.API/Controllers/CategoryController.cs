using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Models;
using ProductMicroservice.ApplicationCore.Services;

namespace ProductMicroservice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("SaveCategory")]
        public async Task<IActionResult> SaveCategory(
            [FromBody] Category category)
        {
            var result = await _categoryService.SaveCategory(category);

            return Ok(result);
        }

        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            var result = await _categoryService.GetAllCategory();

            return Ok(result);
        }

        [HttpGet("GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _categoryService.GetCategoryById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Category deleted successfully."
            });
        }

        [HttpGet("GetCategoryByParentCategoryId")]
        public async Task<IActionResult> GetCategoryByParentCategoryId(
            int parentCategoryId)
        {
            var result = await _categoryService
                .GetCategoryByParentCategoryId(parentCategoryId);

            return Ok(result);
        }
    }
}