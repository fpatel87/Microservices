using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Services;

namespace OrderMicroservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetCustomerAddressByUserId")]
        public IActionResult GetCustomerAddressByUserId(int userId)
        {
            var customer = _customerService.GetCustomerByUserId(userId);

            if (customer == null)
                return NotFound();

            var result = new
            {
                customer.Id,
                customer.FirstName,
                customer.LastName,
                customer.Gender,
                customer.Phone,
                customer.Profile_PIC,
                customer.Type,
                customer.UserId,

                UserAddresses = customer.UserAddresses.Select(ua => new
                {
                    ua.Id,
                    ua.Customer_Id,
                    ua.Address_Id,
                    ua.IsDefaultAddress,

                    Address = ua.Address == null ? null : new
                    {
                        ua.Address.Id,
                        ua.Address.Street1,
                        ua.Address.Street2,
                        ua.Address.City,
                        ua.Address.Zipcode,
                        ua.Address.State,
                        ua.Address.Country
                    }
                })
            };

            return Ok(result);
        }

        [HttpPost("SaveCutomerAddress")]
        public IActionResult SaveCutomerAddress([FromBody] UserAddress userAddress)
        {
            var customer = _customerService.GetCustomerById(userAddress.Customer_Id);

            if (customer == null)
                return NotFound("Customer not found.");

            customer.UserAddresses.Add(userAddress);

            _customerService.UpdateCustomer(customer);

            return Ok(new
            {
                userAddress.Id,
                userAddress.Customer_Id,
                userAddress.Address_Id,
                userAddress.IsDefaultAddress
            });
        }
    }
}