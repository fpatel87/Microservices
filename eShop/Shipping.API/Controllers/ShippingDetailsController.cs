using Microsoft.AspNetCore.Mvc;
using ShippingMicroservice.ApplicationCore.DTOs;
using ShippingMicroservice.ApplicationCore.Entities;
using ShippingMicroservice.ApplicationCore.Services;

namespace ShippingMicroservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ShippingDetailsController : ControllerBase
    {
        private readonly IShippingDetailsService _service;

        public ShippingDetailsController(
            IShippingDetailsService service)
        {
            _service = service;
        }

        // GET: api/ShippingDetails/order/1
        // Customer can view shipping status by Order ID
        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetByOrderId(int orderId)
        {
            var shippingDetails =
                await _service.GetByOrderIdAsync(orderId);

            if (shippingDetails == null)
            {
                return NotFound();
            }

            var response = new ShippingDetailsResponseModel
            {
                Id = shippingDetails.Id,
                OrderId = shippingDetails.OrderId,
                ShipperId = shippingDetails.ShipperId,
                ShippingStatus = shippingDetails.ShippingStatus,
                TrackingNumber = shippingDetails.TrackingNumber,
                ShipperName = shippingDetails.Shipper?.Name
            };

            return Ok(response);
        }

        // GET: api/ShippingDetails/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var shippingDetails =
                await _service.GetByIdAsync(id);

            if (shippingDetails == null)
            {
                return NotFound();
            }

            var response = new ShippingDetailsResponseModel
            {
                Id = shippingDetails.Id,
                OrderId = shippingDetails.OrderId,
                ShipperId = shippingDetails.ShipperId,
                ShippingStatus = shippingDetails.ShippingStatus,
                TrackingNumber = shippingDetails.TrackingNumber,
                ShipperName = shippingDetails.Shipper?.Name
            };

            return Ok(response);
        }

        // POST: api/ShippingDetails
        // Admin creates shipping details
        [HttpPost]
        public async Task<IActionResult> Create(
            ShippingDetailsRequestModel request)
        {
            var shippingDetails = new ShippingDetails
            {
                OrderId = request.OrderId,
                ShipperId = request.ShipperId,
                ShippingStatus = request.ShippingStatus,
                TrackingNumber = request.TrackingNumber
            };

            var createdShippingDetails =
                await _service.CreateAsync(shippingDetails);

            var response = new ShippingDetailsResponseModel
            {
                Id = createdShippingDetails.Id,
                OrderId = createdShippingDetails.OrderId,
                ShipperId = createdShippingDetails.ShipperId,
                ShippingStatus =
                    createdShippingDetails.ShippingStatus,
                TrackingNumber =
                    createdShippingDetails.TrackingNumber,
                ShipperName =
                    createdShippingDetails.Shipper?.Name
            };

            return CreatedAtAction(
                nameof(GetById),
                new { id = response.Id },
                response);
        }

        // PUT: api/ShippingDetails/1/status
        // Admin updates shipping status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(
            int id,
            [FromBody] string shippingStatus)
        {
            var updatedShippingDetails =
                await _service.UpdateStatusAsync(
                    id,
                    shippingStatus);

            if (updatedShippingDetails == null)
            {
                return NotFound();
            }

            var response = new ShippingDetailsResponseModel
            {
                Id = updatedShippingDetails.Id,
                OrderId = updatedShippingDetails.OrderId,
                ShipperId = updatedShippingDetails.ShipperId,
                ShippingStatus =
                    updatedShippingDetails.ShippingStatus,
                TrackingNumber =
                    updatedShippingDetails.TrackingNumber,
                ShipperName =
                    updatedShippingDetails.Shipper?.Name
            };

            return Ok(response);
        }
    }
}
