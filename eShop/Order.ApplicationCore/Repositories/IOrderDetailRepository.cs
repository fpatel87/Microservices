using OrderMicroservice.ApplicationCore.Entities;

namespace OrderMicroservice.ApplicationCore.Repositories
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetByOrderId(int orderId);

        OrderDetail? GetById(int id);

        void Add(OrderDetail orderDetail);

        void Update(OrderDetail orderDetail);

        void Delete(int id);
    }
}