using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Repositories;
using OrderMicroservice.ApplicationCore.Services;

namespace OrderMicroservice.Infrastructure.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public IEnumerable<OrderDetail> GetByOrderId(int orderId)
        {
            return _orderDetailRepository.GetByOrderId(orderId);
        }

        public OrderDetail? GetById(int id)
        {
            return _orderDetailRepository.GetById(id);
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailRepository.Add(orderDetail);
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            _orderDetailRepository.Update(orderDetail);
        }

        public void DeleteOrderDetail(int id)
        {
            _orderDetailRepository.Delete(id);
        }
    }
}