namespace OrderMicroservice.ApplicationCore.Entities
{
    public class PaymentMethod
    {
        public int Id { get; set; }

        public int Payment_Type_Id { get; set; }

        public int? CustomerId { get; set; }

        public string? Provider { get; set; }

        public string? AccountNumber { get; set; }

        public string? Expiry { get; set; }

        public bool? IsDefault { get; set; }

        public PaymentType? PaymentType { get; set; }

        public Customer? Customer { get; set; }
    }
}