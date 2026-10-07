using OrderMicroservice.ApplicationCore.Entities;

namespace OrderMicroservice.ApplicationCore.Models
{
    public class CustomerAddressRequest
    {
        public int CustomerId { get; set; }
        public Address Address { get; set; } = new Address();
        public bool IsDefaultAddress { get; set; }
    }
}