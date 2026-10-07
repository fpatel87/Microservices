using Microsoft.EntityFrameworkCore;
using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Repositories;
using OrderMicroservice.Infrastructure.Data;

namespace OrderMicroservice.Infrastructure.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ShopDbContext _context;

        public ShoppingCartRepository(ShopDbContext context)
        {
            _context = context;
        }

        public ShoppingCart? GetCartByCustomerId(int customerId)
        {
            return _context.ShoppingCarts
                .Include(c => c.ShoppingCartItems)
                .FirstOrDefault(c => c.CustomerId == customerId);
        }

        public void Add(ShoppingCart cart)
        {
            _context.ShoppingCarts.Add(cart);
            _context.SaveChanges();
        }

        public void Update(ShoppingCart cart)
        {
            _context.ShoppingCarts.Update(cart);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var cart = _context.ShoppingCarts
                .FirstOrDefault(c => c.Id == id);

            if (cart != null)
            {
                _context.ShoppingCarts.Remove(cart);
                _context.SaveChanges();
            }
        }
    }
}