using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Repositories;
using OrderMicroservice.ApplicationCore.Services;

namespace OrderMicroservice.Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public IEnumerable<PaymentMethod> GetPaymentsByCustomerId(int customerId)
        {
            return _paymentRepository.GetPaymentsByCustomerId(customerId);
        }

        public PaymentMethod? GetPaymentById(int id)
        {
            return _paymentRepository.GetPaymentById(id);
        }

        public void AddPayment(PaymentMethod payment)
        {
            _paymentRepository.Add(payment);
        }

        public void UpdatePayment(PaymentMethod payment)
        {
            _paymentRepository.Update(payment);
        }

        public void DeletePayment(int id)
        {
            _paymentRepository.Delete(id);
        }
    }
}