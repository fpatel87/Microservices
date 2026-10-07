using OrderMicroservice.ApplicationCore.Entities;

namespace OrderMicroservice.ApplicationCore.Services
{
    public interface IShoppingCartItemService
    {
        ShoppingCartItem? GetById(int id);

        void AddItem(ShoppingCartItem item);

        void UpdateItem(ShoppingCartItem item);

        void DeleteItem(int id);
    }
}