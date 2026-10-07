using ReviewsMicroservice.ApplicationCore.Models;

namespace ReviewsMicroservice.ApplicationCore.Repositories
{
    public interface ICustomerReviewRepository
    {
        Task<List<CustomerReview>> GetAllAsync();

        Task<CustomerReview?> GetByIdAsync(int id);

        Task<List<CustomerReview>> GetByUserIdAsync(string userId);

        Task<List<CustomerReview>> GetByProductIdAsync(string productId);

        Task<List<CustomerReview>> GetByYearAsync(int year);

        Task<CustomerReview> CreateAsync(CustomerReview review);

        Task<CustomerReview?> UpdateAsync(CustomerReview review);

        Task<bool> DeleteAsync(int id);

        Task<bool> ApproveAsync(int id);

        Task<bool> RejectAsync(int id);
    }
}