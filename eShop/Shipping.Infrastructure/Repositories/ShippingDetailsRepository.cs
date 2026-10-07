using Microsoft.EntityFrameworkCore;
using ShippingMicroservice.ApplicationCore.Entities;
using ShippingMicroservice.ApplicationCore.Repositories;
using ShippingMicroservice.Infrastructure.Data;

namespace ShippingMicroservice.Infrastructure.Repositories
{
    public class ShippingDetailsRepository : IShippingDetailsRepository
    {
        private readonly ShippingDbContext _context;

        public ShippingDetailsRepository(ShippingDbContext context)
        {
            _context = context;
        }

        public async Task<ShippingDetails?> GetByOrderIdAsync(int orderId)
        {
            return await _context.ShippingDetails
                .Include(sd => sd.Shipper)
                .FirstOrDefaultAsync(sd => sd.OrderId == orderId);
        }

        public async Task<ShippingDetails?> GetByIdAsync(int id)
        {
            return await _context.ShippingDetails
                .Include(sd => sd.Shipper)
                .FirstOrDefaultAsync(sd => sd.Id == id);
        }

        public async Task<ShippingDetails> CreateAsync(
            ShippingDetails shippingDetails)
        {
            _context.ShippingDetails.Add(shippingDetails);

            await _context.SaveChangesAsync();

            return shippingDetails;
        }

        public async Task<ShippingDetails?> UpdateStatusAsync(
            int id,
            string shippingStatus)
        {
            var shippingDetails = await _context.ShippingDetails
                .FirstOrDefaultAsync(sd => sd.Id == id);

            if (shippingDetails == null)
            {
                return null;
            }

            shippingDetails.ShippingStatus = shippingStatus;

            await _context.SaveChangesAsync();

            return shippingDetails;
        }
    }
}