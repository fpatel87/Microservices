using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Services;

namespace OrderMicroservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("GetPaymentByCustomerId")]
        public IActionResult GetPaymentByCustomerId(int customerId)
        {
            var payments = _paymentService.GetPaymentsByCustomerId(customerId);

            var result = payments.Select(p => new
            {
                p.Id,
                p.Payment_Type_Id,
                p.CustomerId,
                p.Provider,
                p.AccountNumber,
                p.Expiry,
                p.IsDefault
            });

            return Ok(result);
        }

        [HttpPost("SavePayment")]
        public IActionResult SavePayment([FromBody] PaymentMethod payment)
        {
            _paymentService.AddPayment(payment);

            return Ok(payment);
        }

        [HttpDelete("DeletePayment")]
        public IActionResult DeletePayment(int id)
        {
            var payment = _paymentService.GetPaymentById(id);

            if (payment == null)
                return NotFound();

            _paymentService.DeletePayment(id);

            return Ok();
        }

        [HttpPut("UpdatePayment")]
        public IActionResult UpdatePayment([FromBody] PaymentMethod payment)
        {
            var existingPayment = _paymentService.GetPaymentById(payment.Id);

            if (existingPayment == null)
                return NotFound();

            _paymentService.UpdatePayment(payment);

            return Ok(payment);
        }
    }
}