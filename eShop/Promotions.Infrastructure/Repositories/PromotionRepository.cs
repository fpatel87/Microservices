using Microsoft.EntityFrameworkCore;
using PromotionsMicroservice.ApplicationCore.Models;
using PromotionsMicroservice.ApplicationCore.Repositories;
using PromotionsMicroservice.Infrastructure.Data;

namespace PromotionsMicroservice.Infrastructure.Repositories
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly PromotionsDbContext _context;

        public PromotionRepository(PromotionsDbContext context)
        {
            _context = context;
        }

        public async Task<List<PromotionSale>> GetAllPromotionsAsync()
        {
            return await _context.PromotionSales
                .Include(x => x.PromotionDetails)
                .ToListAsync();
        }

        public async Task<PromotionSale?> GetPromotionByIdAsync(int id)
        {
            return await _context.PromotionSales
                .Include(x => x.PromotionDetails)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PromotionSale> CreatePromotionAsync(PromotionSale promotion)
        {
            _context.PromotionSales.Add(promotion);
            await _context.SaveChangesAsync();

            return promotion;
        }

        public async Task<PromotionSale?> UpdatePromotionAsync(PromotionSale promotion)
        {
            var existingPromotion = await _context.PromotionSales
                .Include(x => x.PromotionDetails)
                .FirstOrDefaultAsync(x => x.Id == promotion.Id);

            if (existingPromotion == null)
            {
                return null;
            }

            existingPromotion.Name = promotion.Name;
            existingPromotion.Description = promotion.Description;
            existingPromotion.Discount = promotion.Discount;
            existingPromotion.StartDate = promotion.StartDate;
            existingPromotion.EndDate = promotion.EndDate;

            _context.PromotionDetails.RemoveRange(existingPromotion.PromotionDetails);

            existingPromotion.PromotionDetails = promotion.PromotionDetails;

            await _context.SaveChangesAsync();

            return existingPromotion;
        }

        public async Task<bool> DeletePromotionAsync(int id)
        {
            var promotion = await _context.PromotionSales
                .FirstOrDefaultAsync(x => x.Id == id);

            if (promotion == null)
            {
                return false;
            }

            _context.PromotionSales.Remove(promotion);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<PromotionSale>> GetActivePromotionsAsync()
        {
            var currentDate = DateTime.UtcNow;

            return await _context.PromotionSales
                .Include(x => x.PromotionDetails)
                .Where(x => x.StartDate <= currentDate && x.EndDate >= currentDate)
                .ToListAsync();
        }

        public async Task<List<PromotionSale>> GetPromotionsByProductNameAsync(string productName)
        {
            return await _context.PromotionSales
                .Include(x => x.PromotionDetails)
                .Where(x => x.PromotionDetails
                    .Any(d => d.ProductCategoryName.Contains(productName)))
                .ToListAsync();
        }
    }
}