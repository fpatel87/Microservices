using Microsoft.EntityFrameworkCore;
using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Repositories;
using OrderMicroservice.Infrastructure.Data;

namespace OrderMicroservice.Infrastructure.Repositories
{
    public class ShoppingCartItemRepository : IShoppingCartItemRepository
    {
        private readonly ShopDbContext _context;

        public ShoppingCartItemRepository(ShopDbContext context)
        {
            _context = context;
        }

        public ShoppingCartItem? GetById(int id)
        {
            return _context.ShoppingCartItems
                .Include(i => i.ShoppingCart)
                .FirstOrDefault(i => i.Id == id);
        }

        public void Add(ShoppingCartItem item)
        {
            _context.ShoppingCartItems.Add(item);
            _context.SaveChanges();
        }

        public void Update(ShoppingCartItem item)
        {
            _context.ShoppingCartItems.Update(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _context.ShoppingCartItems
                .FirstOrDefault(i => i.Id == id);

            if (item != null)
            {
                _context.ShoppingCartItems.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}