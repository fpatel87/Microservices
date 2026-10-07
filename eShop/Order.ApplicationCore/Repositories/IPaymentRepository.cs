using OrderMicroservice.ApplicationCore.Entities;

namespace OrderMicroservice.ApplicationCore.Repositories
{
    public interface IPaymentRepository
    {
        IEnumerable<PaymentMethod> GetPaymentsByCustomerId(int customerId);

        PaymentMethod? GetPaymentById(int id);

        void Add(PaymentMethod payment);

        void Update(PaymentMethod payment);

        void Delete(int id);
    }
}