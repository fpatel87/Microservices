using OrderMicroservice.ApplicationCore.Entities;
using OrderMicroservice.ApplicationCore.Repositories;
using OrderMicroservice.ApplicationCore.Services;

namespace OrderMicroservice.Infrastructure.Services
{
    public class ShoppingCartItemService : IShoppingCartItemService
    {
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

        public ShoppingCartItemService(
            IShoppingCartItemRepository shoppingCartItemRepository)
        {
            _shoppingCartItemRepository = shoppingCartItemRepository;
        }

        public ShoppingCartItem? GetById(int id)
        {
            return _shoppingCartItemRepository.GetById(id);
        }

        public void AddItem(ShoppingCartItem item)
        {
            _shoppingCartItemRepository.Add(item);
        }

        public void UpdateItem(ShoppingCartItem item)
        {
            _shoppingCartItemRepository.Update(item);
        }

        public void DeleteItem(int id)
        {
            _shoppingCartItemRepository.Delete(id);
        }
    }
}