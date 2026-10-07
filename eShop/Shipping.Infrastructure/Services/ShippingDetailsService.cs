using ShippingMicroservice.ApplicationCore.Entities;
using ShippingMicroservice.ApplicationCore.Repositories;
using ShippingMicroservice.ApplicationCore.Services;

namespace ShippingMicroservice.Infrastructure.Services
{
    public class ShippingDetailsService : IShippingDetailsService
    {
        private readonly IShippingDetailsRepository _repository;

        public ShippingDetailsService(
            IShippingDetailsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ShippingDetails?> GetByOrderIdAsync(
            int orderId)
        {
            return await _repository.GetByOrderIdAsync(orderId);
        }

        public async Task<ShippingDetails?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<ShippingDetails> CreateAsync(
            ShippingDetails shippingDetails)
        {
            return await _repository.CreateAsync(shippingDetails);
        }

        public async Task<ShippingDetails?> UpdateStatusAsync(
            int id,
            string shippingStatus)
        {
            return await _repository.UpdateStatusAsync(
                id,
                shippingStatus);
        }
    }
}