using OrderMicroservice.ApplicationCore.Entities;

namespace OrderMicroservice.ApplicationCore.Repositories
{
    public interface ICustomerRepository
    {
        Customer? GetCustomerById(int id);

        Customer? GetCustomerByUserId(int userId);

        void Add(Customer customer);

        void Update(Customer customer);
    }
}