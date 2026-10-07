using Microsoft.AspNetCore.Mvc;
using ShippingMicroservice.ApplicationCore.DTOs;
using ShippingMicroservice.ApplicationCore.Entities;
using ShippingMicroservice.ApplicationCore.Services;

namespace ShippingMicroservice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperService _service;

        public ShipperController(IShipperService service)
        {
            _service = service;
        }

        // GET: api/Shipper
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shippers = await _service.GetAllAsync();

            var response = shippers.Select(s => new ShipperResponseModel
            {
                Id = s.Id,
                Name = s.Name,
                EmailId = s.EmailId,
                Phone = s.Phone,
                ContactPerson = s.ContactPerson
            });

            return Ok(response);
        }

        // GET: api/Shipper/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var shipper = await _service.GetByIdAsync(id);

            if (shipper == null)
            {
                return NotFound();
            }

            var response = new ShipperResponseModel
            {
                Id = shipper.Id,
                Name = shipper.Name,
                EmailId = shipper.EmailId,
                Phone = shipper.Phone,
                ContactPerson = shipper.ContactPerson
            };

            return Ok(response);
        }

        // POST: api/Shipper
        [HttpPost]
        public async Task<IActionResult> Create(
            ShipperRequestModel request)
        {
            var shipper = new Shipper
            {
                Name = request.Name,
                EmailId = request.EmailId,
                Phone = request.Phone,
                ContactPerson = request.ContactPerson
            };

            var createdShipper = await _service.CreateAsync(shipper);

            var response = new ShipperResponseModel
            {
                Id = createdShipper.Id,
                Name = createdShipper.Name,
                EmailId = createdShipper.EmailId,
                Phone = createdShipper.Phone,
                ContactPerson = createdShipper.ContactPerson
            };

            return CreatedAtAction(
                nameof(GetById),
                new { id = response.Id },
                response);
        }

        // PUT: api/Shipper
        [HttpPut]
        public async Task<IActionResult> Update(
            int id,
            ShipperRequestModel request)
        {
            var shipper = new Shipper
            {
                Id = id,
                Name = request.Name,
                EmailId = request.EmailId,
                Phone = request.Phone,
                ContactPerson = request.ContactPerson
            };

            var updatedShipper = await _service.UpdateAsync(shipper);

            if (updatedShipper == null)
            {
                return NotFound();
            }

            var response = new ShipperResponseModel
            {
                Id = updatedShipper.Id,
                Name = updatedShipper.Name,
                EmailId = updatedShipper.EmailId,
                Phone = updatedShipper.Phone,
                ContactPerson = updatedShipper.ContactPerson
            };

            return Ok(response);
        }

        // DELETE: api/Shipper/delete-5
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

        // GET: api/Shipper/region/Texas
        [HttpGet("region/{region}")]
        public async Task<IActionResult> GetByRegion(string region)
        {
            var shippers = await _service.GetByRegionAsync(region);

            var response = shippers.Select(s => new ShipperResponseModel
            {
                Id = s.Id,
                Name = s.Name,
                EmailId = s.EmailId,
                Phone = s.Phone,
                ContactPerson = s.ContactPerson
            });

            return Ok(response);
        }
    }
}
