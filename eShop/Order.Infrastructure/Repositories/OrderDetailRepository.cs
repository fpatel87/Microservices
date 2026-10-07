using Microsoft.EntityFrameworkCore;
using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Repositories;
using OrderMicroservice.Infrastructure.Data;

namespace OrderMicroservice.Infrastructure.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly ShopDbContext _context;

        public OrderDetailRepository(ShopDbContext context)
        {
            _context = context;
        }

        public IEnumerable<OrderDetail> GetByOrderId(int orderId)
        {
            return _context.OrderDetails
                .Where(od => od.Order_Id == orderId)
                .ToList();
        }

        public OrderDetail? GetById(int id)
        {
            return _context.OrderDetails
                .FirstOrDefault(od => od.Id == id);
        }

        public void Add(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();
        }

        public void Update(OrderDetail orderDetail)
        {
            _context.OrderDetails.Update(orderDetail);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var orderDetail = _context.OrderDetails
                .FirstOrDefault(od => od.Id == id);

            if (orderDetail != null)
            {
                _context.OrderDetails.Remove(orderDetail);
                _context.SaveChanges();
            }
        }
    }
}