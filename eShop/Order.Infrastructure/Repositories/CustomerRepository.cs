using Microsoft.EntityFrameworkCore;
using OrderMicroservice.ApplicationCore.Repositories;
using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.Infrastructure.Data;

namespace OrderMicroservice.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ShopDbContext _context;

        public CustomerRepository(ShopDbContext context)
        {
            _context = context;
        }

        public Customer? GetCustomerById(int id)
        {
            return _context.Customers
                .Include(c => c.UserAddresses)
                .ThenInclude(ua => ua.Address)
                .FirstOrDefault(c => c.Id == id);
        }

        public Customer? GetCustomerByUserId(int userId)
        {
            return _context.Customers
                .Include(c => c.UserAddresses)
                .ThenInclude(ua => ua.Address)
                .FirstOrDefault(c => c.UserId == userId);
        }

        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }
    }
}