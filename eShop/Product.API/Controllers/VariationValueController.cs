using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.ApplicationCore.Models;
using ProductMicroservice.ApplicationCore.Services;

namespace ProductMicroservice.API.Controllers
{
    [Route("api/VariationValue")]
    [ApiController]
    public class VariationValueController : ControllerBase
    {
        private readonly IVariationValueService _variationValueService;

        public VariationValueController(
            IVariationValueService variationValueService)
        {
            _variationValueService = variationValueService;
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(
            [FromBody] VariationValue variationValue)
        {
            var result = await _variationValueService.Save(
                variationValue);

            return Ok(result);
        }

        [HttpGet("GetVariationId")]
        public async Task<IActionResult> GetVariationId(
            int variationId)
        {
            var result = await _variationValueService
                .GetVariationId(variationId);

            return Ok(result);
        }
    }
}