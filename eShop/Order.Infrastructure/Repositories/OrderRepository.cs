using Microsoft.EntityFrameworkCore;
using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Repositories;
using OrderMicroservice.Infrastructure.Data;

namespace OrderMicroservice.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShopDbContext _context;

        public OrderRepository(ShopDbContext context)
        {
            _context = context;
        }

        public IEnumerable<OrderMicroservice.ApplicationCore.Entities.Order> GetAllOrders()
        {
            return _context.Orders
                .Include(o => o.OrderDetails)
                .OrderByDescending(o => o.Order_Date)
                .ToList();
        }

        public OrderMicroservice.ApplicationCore.Entities.Order? GetOrderById(int id)
        {
            return _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<OrderMicroservice.ApplicationCore.Entities.Order> GetOrdersByCustomerId(int customerId)
        {
            return _context.Orders
                .Include(o => o.OrderDetails)
                .Where(o => o.CustomerId == customerId)
                .OrderByDescending(o => o.Order_Date)
                .ToList();
        }

        public void Add(OrderMicroservice.ApplicationCore.Entities.Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Update(OrderMicroservice.ApplicationCore.Entities.Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }
    }
}