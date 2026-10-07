using OrderMicroservice.ApplicationCore.Entities;

namespace OrderMicroservice.ApplicationCore.Services
{
    public interface ICustomerService
    {
        Customer? GetCustomerById(int id);

        Customer? GetCustomerByUserId(int userId);

        void AddCustomer(Customer customer);

        void UpdateCustomer(Customer customer);
    }
}