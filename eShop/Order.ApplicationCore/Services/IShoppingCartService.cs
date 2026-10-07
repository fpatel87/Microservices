using OrderMicroservice.ApplicationCore.Entities;

namespace OrderMicroservice.ApplicationCore.Services
{
    public interface IShoppingCartService
    {
        ShoppingCart? GetCartByCustomerId(int customerId);

        void AddCart(ShoppingCart cart);

        void UpdateCart(ShoppingCart cart);

        void DeleteCart(int id);
    }
}