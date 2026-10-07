using OrderMicroservice.ApplicationCore.Entities;

namespace OrderMicroservice.ApplicationCore.Services
{
    public interface IOrderService
    {
        IEnumerable<OrderMicroservice.ApplicationCore.Entities.Order> GetAllOrders();

        OrderMicroservice.ApplicationCore.Entities.Order? GetOrderById(int id);

        IEnumerable<OrderMicroservice.ApplicationCore.Entities.Order> GetOrdersByCustomerId(int customerId);

        void CreateOrder(OrderMicroservice.ApplicationCore.Entities.Order order);

        void UpdateOrder(OrderMicroservice.ApplicationCore.Entities.Order order);

        void CancelOrder(int id);
    }
}