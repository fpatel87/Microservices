using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Services;
using OrderMicroservice.ApplicationCore.Repositories;


namespace OrderMicroservice.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer? GetCustomerById(int id)
        {
            return _customerRepository.GetCustomerById(id);
        }

        public Customer? GetCustomerByUserId(int userId)
        {
            return _customerRepository.GetCustomerByUserId(userId);
        }

        public void AddCustomer(Customer customer)
        {
            _customerRepository.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.Update(customer);
        }
    }
}