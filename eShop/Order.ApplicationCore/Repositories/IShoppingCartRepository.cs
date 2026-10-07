using OrderMicroservice.ApplicationCore.Entities;

namespace OrderMicroservice.ApplicationCore.Repositories
{
    public interface IShoppingCartRepository
    {
        ShoppingCart? GetCartByCustomerId(int customerId);

        void Add(ShoppingCart cart);

        void Update(ShoppingCart cart);

        void Delete(int id);
    }
}