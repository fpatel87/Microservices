using ShippingMicroservice.ApplicationCore.Entities;

namespace ShippingMicroservice.ApplicationCore.Services
{
    public interface IShippingDetailsService
    {
        Task<ShippingDetails?> GetByOrderIdAsync(int orderId);

        Task<ShippingDetails?> GetByIdAsync(int id);

        Task<ShippingDetails> CreateAsync(
            ShippingDetails shippingDetails);

        Task<ShippingDetails?> UpdateStatusAsync(
            int id,
            string shippingStatus);
    }
}