using Microsoft.AspNetCore.Mvc;
using PromotionsMicroservice.ApplicationCore.Models;
using PromotionsMicroservice.ApplicationCore.Services;

namespace PromotionsMicroservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService _service;

        public PromotionController(IPromotionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPromotions()
        {
            var promotions = await _service.GetAllPromotionsAsync();

            return Ok(promotions);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePromotion(PromotionSale promotion)
        {
            var createdPromotion = await _service.CreatePromotionAsync(promotion);

            return Ok(createdPromotion);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePromotion(PromotionSale promotion)
        {
            var updatedPromotion = await _service.UpdatePromotionAsync(promotion);

            if (updatedPromotion == null)
            {
                return NotFound();
            }

            return Ok(updatedPromotion);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPromotionById(int id)
        {
            var promotion = await _service.GetPromotionByIdAsync(id);

            if (promotion == null)
            {
                return NotFound();
            }

            return Ok(promotion);
        }

        [HttpDelete("delete-{id}")]
        public async Task<IActionResult> DeletePromotion(int id)
        {
            var deleted = await _service.DeletePromotionAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("promotionByProductName")]
        public async Task<IActionResult> GetPromotionsByProductName(
            [FromQuery] string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                return BadRequest("Product name is required.");
            }

            var promotions =
                await _service.GetPromotionsByProductNameAsync(productName);

            return Ok(promotions);
        }

        [HttpGet("activePromotions")]
        public async Task<IActionResult> GetActivePromotions()
        {
            var promotions = await _service.GetActivePromotionsAsync();

            return Ok(promotions);
        }
    }
}