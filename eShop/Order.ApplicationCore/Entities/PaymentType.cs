namespace OrderMicroservice.ApplicationCore.Entities
{
    public class PaymentType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<PaymentMethod> PaymentMethods { get; set; }
            = new List<PaymentMethod>();
    }
}