using OrderMicroservice.ApplicationCore.Entities;

namespace OrderMicroservice.ApplicationCore.Models
{
    public class PaymentRequest
    {
        public int CustomerId { get; set; }
        public PaymentMethod PaymentMethod { get; set; } = new PaymentMethod();
    }
}