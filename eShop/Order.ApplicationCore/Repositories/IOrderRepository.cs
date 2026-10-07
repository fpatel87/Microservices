using OrderMicroservice.ApplicationCore.Entities;

namespace OrderMicroservice.ApplicationCore.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<OrderMicroservice.ApplicationCore.Entities.Order> GetAllOrders();

        OrderMicroservice.ApplicationCore.Entities.Order? GetOrderById(int id);

        IEnumerable<OrderMicroservice.ApplicationCore.Entities.Order> GetOrdersByCustomerId(int customerId);

        void Add(OrderMicroservice.ApplicationCore.Entities.Order order);

        void Update(OrderMicroservice.ApplicationCore.Entities.Order order);
    }
}