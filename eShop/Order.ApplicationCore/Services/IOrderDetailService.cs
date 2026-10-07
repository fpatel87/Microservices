using OrderMicroservice.ApplicationCore.Entities;

namespace OrderMicroservice.ApplicationCore.Services
{
    public interface IOrderDetailService
    {
        IEnumerable<OrderDetail> GetByOrderId(int orderId);

        OrderDetail? GetById(int id);

        void AddOrderDetail(OrderDetail orderDetail);

        void UpdateOrderDetail(OrderDetail orderDetail);

        void DeleteOrderDetail(int id);
    }
}