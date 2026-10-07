using ReviewsMicroservice.ApplicationCore.Models;
using ReviewsMicroservice.ApplicationCore.Repositories;
using ReviewsMicroservice.ApplicationCore.Services;

namespace ReviewsMicroservice.Infrastructure.Services
{
    public class CustomerReviewService : ICustomerReviewService
    {
        private readonly ICustomerReviewRepository _repository;

        public CustomerReviewService(ICustomerReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CustomerReview>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CustomerReview?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<CustomerReview>> GetByUserIdAsync(string userId)
        {
            return await _repository.GetByUserIdAsync(userId);
        }

        public async Task<List<CustomerReview>> GetByProductIdAsync(string productId)
        {
            return await _repository.GetByProductIdAsync(productId);
        }

        public async Task<List<CustomerReview>> GetByYearAsync(int year)
        {
            return await _repository.GetByYearAsync(year);
        }

        public async Task<CustomerReview> CreateAsync(CustomerReview review)
        {
            if (string.IsNullOrWhiteSpace(review.CustomerName) ||
                review.CustomerName.Length < 2)
            {
                throw new ArgumentException("Customer name must be at least 2 characters.");
            }

            if (string.IsNullOrWhiteSpace(review.ProductName) ||
                review.ProductName.Length < 2)
            {
                throw new ArgumentException("Product name must be at least 2 characters.");
            }

            if (string.IsNullOrWhiteSpace(review.Comment) ||
                review.Comment.Length < 2)
            {
                throw new ArgumentException("Comment must be at least 2 characters.");
            }

            if (review.RatingValue < 1 || review.RatingValue > 5)
            {
                throw new ArgumentException("Rating must be between 1 and 5.");
            }

            review.Status = "Pending";

            return await _repository.CreateAsync(review);
        }

        public async Task<CustomerReview?> UpdateAsync(CustomerReview review)
        {
            if (string.IsNullOrWhiteSpace(review.CustomerName) ||
                review.CustomerName.Length < 2)
            {
                throw new ArgumentException("Customer name must be at least 2 characters.");
            }

            if (string.IsNullOrWhiteSpace(review.ProductName) ||
                review.ProductName.Length < 2)
            {
                throw new ArgumentException("Product name must be at least 2 characters.");
            }

            if (string.IsNullOrWhiteSpace(review.Comment) ||
                review.Comment.Length < 2)
            {
                throw new ArgumentException("Comment must be at least 2 characters.");
            }

            if (review.RatingValue < 1 || review.RatingValue > 5)
            {
                throw new ArgumentException("Rating must be between 1 and 5.");
            }

            return await _repository.UpdateAsync(review);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<bool> ApproveAsync(int id)
        {
            return await _repository.ApproveAsync(id);
        }

        public async Task<bool> RejectAsync(int id)
        {
            return await _repository.RejectAsync(id);
        }
    }
}