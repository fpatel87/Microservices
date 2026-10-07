using PromotionsMicroservice.ApplicationCore.Models;
using PromotionsMicroservice.ApplicationCore.Repositories;
using PromotionsMicroservice.ApplicationCore.Services;

namespace PromotionsMicroservice.Infrastructure.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _repository;

        public PromotionService(IPromotionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PromotionSale>> GetAllPromotionsAsync()
        {
            return await _repository.GetAllPromotionsAsync();
        }

        public async Task<PromotionSale?> GetPromotionByIdAsync(int id)
        {
            return await _repository.GetPromotionByIdAsync(id);
        }

        public async Task<PromotionSale> CreatePromotionAsync(PromotionSale promotion)
        {
            return await _repository.CreatePromotionAsync(promotion);
        }

        public async Task<PromotionSale?> UpdatePromotionAsync(PromotionSale promotion)
        {
            return await _repository.UpdatePromotionAsync(promotion);
        }

        public async Task<bool> DeletePromotionAsync(int id)
        {
            return await _repository.DeletePromotionAsync(id);
        }

        public async Task<List<PromotionSale>> GetActivePromotionsAsync()
        {
            return await _repository.GetActivePromotionsAsync();
        }

        public async Task<List<PromotionSale>> GetPromotionsByProductNameAsync(string productName)
        {
            return await _repository.GetPromotionsByProductNameAsync(productName);
        }
    }
}