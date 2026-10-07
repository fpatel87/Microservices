using OrderMicroservice.ApplicationCore.Entities;

namespace OrderMicroservice.ApplicationCore.Services
{
    public interface IPaymentService
    {
        IEnumerable<PaymentMethod> GetPaymentsByCustomerId(int customerId);

        PaymentMethod? GetPaymentById(int id);

        void AddPayment(PaymentMethod payment);

        void UpdatePayment(PaymentMethod payment);

        void DeletePayment(int id);
    }
}