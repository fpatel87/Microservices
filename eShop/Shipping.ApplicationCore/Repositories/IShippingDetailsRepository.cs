using ShippingMicroservice.ApplicationCore.Entities;

namespace ShippingMicroservice.ApplicationCore.Repositories
{
    public interface IShippingDetailsRepository
    {
        Task<ShippingDetails?> GetByOrderIdAsync(int orderId);

        Task<ShippingDetails?> GetByIdAsync(int id);

        Task<ShippingDetails> CreateAsync(ShippingDetails shippingDetails);

        Task<ShippingDetails?> UpdateStatusAsync(
            int id,
            string shippingStatus);
    }
}