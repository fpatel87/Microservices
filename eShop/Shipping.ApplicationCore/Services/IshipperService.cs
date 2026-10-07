using ShippingMicroservice.ApplicationCore.Entities;

namespace ShippingMicroservice.ApplicationCore.Services
{
    public interface IShipperService
    {
        Task<IEnumerable<Shipper>> GetAllAsync();

        Task<Shipper?> GetByIdAsync(int id);

        Task<Shipper> CreateAsync(Shipper shipper);

        Task<Shipper?> UpdateAsync(Shipper shipper);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<Shipper>> GetByRegionAsync(string region);
    }
}