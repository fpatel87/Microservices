using OrderMicroservice.ApplicationCore.Entities;


namespace OrderMicroservice.ApplicationCore.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime Order_Date { get; set; }

        public int? CustomerId { get; set; }

        public string? CustomerName { get; set; }

        public int? PaymentMethodId { get; set; }

        public string? PaymentName { get; set; }

        public string? ShippingAddress { get; set; }

        public string? ShippingMethod { get; set; }

        public decimal BillAmount { get; set; }

        public string? Order_Status { get; set; }

        public Customer? Customer { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
            = new List<OrderDetail>();
    }
}