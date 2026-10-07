using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Services;
using OrderMicroservice.ApplicationCore.Repositories;

namespace OrderMicroservice.Infrastructure.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public ShoppingCart? GetCartByCustomerId(int customerId)
        {
            return _shoppingCartRepository.GetCartByCustomerId(customerId);
        }

        public void AddCart(ShoppingCart cart)
        {
            _shoppingCartRepository.Add(cart);
        }

        public void UpdateCart(ShoppingCart cart)
        {
            _shoppingCartRepository.Update(cart);
        }

        public void DeleteCart(int id)
        {
            _shoppingCartRepository.Delete(id);
        }
    }
}