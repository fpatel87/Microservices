using OrderMicroservice.ApplicationCore.Entities;

namespace OrderMicroservice.ApplicationCore.Repositories
{
    public interface IShoppingCartItemRepository
    {
        ShoppingCartItem? GetById(int id);

        void Add(ShoppingCartItem item);

        void Update(ShoppingCartItem item);

        void Delete(int id);
    }
}