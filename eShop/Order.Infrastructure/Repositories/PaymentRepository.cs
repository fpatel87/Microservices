using Microsoft.EntityFrameworkCore;
using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Repositories;
using OrderMicroservice.Infrastructure.Data;

namespace OrderMicroservice.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ShopDbContext _context;

        public PaymentRepository(ShopDbContext context)
        {
            _context = context;
        }

        public IEnumerable<PaymentMethod> GetPaymentsByCustomerId(int customerId)
        {
            return _context.PaymentMethods
                .Include(p => p.PaymentType)
                .Where(p => p.CustomerId == customerId)
                .ToList();
        }

        public PaymentMethod? GetPaymentById(int id)
        {
            return _context.PaymentMethods
                .Include(p => p.PaymentType)
                .FirstOrDefault(p => p.Id == id);
        }

        public void Add(PaymentMethod payment)
        {
            _context.PaymentMethods.Add(payment);
            _context.SaveChanges();
        }

        public void Update(PaymentMethod payment)
        {
            var existingPayment = _context.PaymentMethods
                .FirstOrDefault(p => p.Id == payment.Id);

            if (existingPayment != null)
            {
                existingPayment.Payment_Type_Id = payment.Payment_Type_Id;
                existingPayment.CustomerId = payment.CustomerId;
                existingPayment.Provider = payment.Provider;
                existingPayment.AccountNumber = payment.AccountNumber;
                existingPayment.Expiry = payment.Expiry;
                existingPayment.IsDefault = payment.IsDefault;

                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var payment = _context.PaymentMethods
                .FirstOrDefault(p => p.Id == id);

            if (payment != null)
            {
                _context.PaymentMethods.Remove(payment);
                _context.SaveChanges();
            }
        }
    }
}