using Microsoft.AspNetCore.Mvc;
using ReviewsMicroservice.ApplicationCore.Models;
using ReviewsMicroservice.ApplicationCore.Services;

namespace ReviewsMicroservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerReviewController : ControllerBase
    {
        private readonly ICustomerReviewService _service;

        public CustomerReviewController(ICustomerReviewService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reviews = await _service.GetAllAsync();

            return Ok(reviews);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerReview review)
        {
            try
            {
                var createdReview = await _service.CreateAsync(review);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = createdReview.Id },
                    createdReview);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerReview review)
        {
            try
            {
                var updatedReview = await _service.UpdateAsync(review);

                if (updatedReview == null)
                {
                    return NotFound();
                }

                return Ok(updatedReview);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var review = await _service.GetByIdAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            var reviews = await _service.GetByUserIdAsync(userId);

            return Ok(reviews);
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProductId(string productId)
        {
            var reviews = await _service.GetByProductIdAsync(productId);

            return Ok(reviews);
        }

        [HttpGet("year/{year}")]
        public async Task<IActionResult> GetByYear(int year)
        {
            var reviews = await _service.GetByYearAsync(year);

            return Ok(reviews);
        }

        [HttpPut("approve/{id}")]
        public async Task<IActionResult> Approve(int id)
        {
            var approved = await _service.ApproveAsync(id);

            if (!approved)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Review approved successfully."
            });
        }

        [HttpPut("reject/{id}")]
        public async Task<IActionResult> Reject(int id)
        {
            var rejected = await _service.RejectAsync(id);

            if (!rejected)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Review rejected successfully."
            });
        }
    }
}