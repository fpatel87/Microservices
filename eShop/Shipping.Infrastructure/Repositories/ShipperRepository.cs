using Microsoft.EntityFrameworkCore;
using ShippingMicroservice.ApplicationCore.Entities;
using ShippingMicroservice.ApplicationCore.Repositories;
using ShippingMicroservice.Infrastructure.Data;

namespace ShippingMicroservice.Infrastructure.Repositories
{
    public class ShipperRepository : IShipperRepository
    {
        private readonly ShippingDbContext _context;

        public ShipperRepository(ShippingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Shipper>> GetAllAsync()
        {
            return await _context.Shippers
                .Include(s => s.ShipperRegions)
                    .ThenInclude(sr => sr.Region)
                .ToListAsync();
        }

        public async Task<Shipper?> GetByIdAsync(int id)
        {
            return await _context.Shippers
                .Include(s => s.ShipperRegions)
                    .ThenInclude(sr => sr.Region)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Shipper> CreateAsync(Shipper shipper)
        {
            _context.Shippers.Add(shipper);

            await _context.SaveChangesAsync();

            return shipper;
        }

        public async Task<Shipper?> UpdateAsync(Shipper shipper)
        {
            var existingShipper = await _context.Shippers
                .FirstOrDefaultAsync(s => s.Id == shipper.Id);

            if (existingShipper == null)
            {
                return null;
            }

            existingShipper.Name = shipper.Name;
            existingShipper.EmailId = shipper.EmailId;
            existingShipper.Phone = shipper.Phone;
            existingShipper.ContactPerson = shipper.ContactPerson;

            await _context.SaveChangesAsync();

            return existingShipper;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var shipper = await _context.Shippers
                .FirstOrDefaultAsync(s => s.Id == id);

            if (shipper == null)
            {
                return false;
            }

            _context.Shippers.Remove(shipper);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Shipper>> GetByRegionAsync(string region)
        {
            return await _context.Shippers
                .Include(s => s.ShipperRegions)
                    .ThenInclude(sr => sr.Region)
                .Where(s => s.ShipperRegions
                    .Any(sr => sr.Region.Name == region && sr.Active))
                .ToListAsync();
        }
    }
}