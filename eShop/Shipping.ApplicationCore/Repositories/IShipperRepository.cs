using ShippingMicroservice.ApplicationCore.Entities;

namespace ShippingMicroservice.ApplicationCore.Repositories
{
    public interface IShipperRepository
    {
        Task<IEnumerable<Shipper>> GetAllAsync();

        Task<Shipper?> GetByIdAsync(int id);

        Task<Shipper> CreateAsync(Shipper shipper);

        Task<Shipper?> UpdateAsync(Shipper shipper);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<Shipper>> GetByRegionAsync(string region);
    }
}