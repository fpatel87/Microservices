using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Services;
using OrderMicroservice.ApplicationCore.Repositories;


namespace OrderMicroservice.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<OrderMicroservice.ApplicationCore.Entities.Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        public OrderMicroservice.ApplicationCore.Entities.Order? GetOrderById(int id)
        {
            return _orderRepository.GetOrderById(id);
        }

        public IEnumerable<OrderMicroservice.ApplicationCore.Entities.Order> GetOrdersByCustomerId(int customerId)
        {
            return _orderRepository.GetOrdersByCustomerId(customerId);
        }

        public void CreateOrder(OrderMicroservice.ApplicationCore.Entities.Order order)
        {
            _orderRepository.Add(order);
        }

        public void UpdateOrder(OrderMicroservice.ApplicationCore.Entities.Order order)
        {
            _orderRepository.Update(order);
        }

        public void CancelOrder(int id)
        {
            var order = _orderRepository.GetOrderById(id);

            if (order != null)
            {
                order.Order_Status = "Cancelled";
                _orderRepository.Update(order);
            }
        }
    }
}