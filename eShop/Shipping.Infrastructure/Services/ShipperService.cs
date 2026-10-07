using ShippingMicroservice.ApplicationCore.Entities;
using ShippingMicroservice.ApplicationCore.Repositories;
using ShippingMicroservice.ApplicationCore.Services;

namespace ShippingMicroservice.Infrastructure.Services
{
    public class ShipperService : IShipperService
    {
        private readonly IShipperRepository _repository;

        public ShipperService(IShipperRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Shipper>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Shipper?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Shipper> CreateAsync(Shipper shipper)
        {
            return await _repository.CreateAsync(shipper);
        }

        public async Task<Shipper?> UpdateAsync(Shipper shipper)
        {
            return await _repository.UpdateAsync(shipper);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Shipper>> GetByRegionAsync(
            string region)
        {
            return await _repository.GetByRegionAsync(region);
        }
    }
}