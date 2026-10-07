using PromotionsMicroservice.ApplicationCore.Models;

namespace PromotionsMicroservice.ApplicationCore.Repositories
{
    public interface IPromotionRepository
    {
        Task<List<PromotionSale>> GetAllPromotionsAsync();

        Task<PromotionSale?> GetPromotionByIdAsync(int id);

        Task<PromotionSale> CreatePromotionAsync(PromotionSale promotion);

        Task<PromotionSale?> UpdatePromotionAsync(PromotionSale promotion);

        Task<bool> DeletePromotionAsync(int id);

        Task<List<PromotionSale>> GetActivePromotionsAsync();

        Task<List<PromotionSale>> GetPromotionsByProductNameAsync(string productName);
    }
}