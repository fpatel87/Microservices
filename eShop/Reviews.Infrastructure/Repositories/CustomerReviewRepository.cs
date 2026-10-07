using Microsoft.EntityFrameworkCore;
using ReviewsMicroservice.ApplicationCore.Models;
using ReviewsMicroservice.ApplicationCore.Repositories;
using ReviewsMicroservice.Infrastructure.Data;

namespace ReviewsMicroservice.Infrastructure.Repositories
{
    public class CustomerReviewRepository : ICustomerReviewRepository
    {
        private readonly ReviewsDbContext _context;

        public CustomerReviewRepository(ReviewsDbContext context)
        {
            _context = context;
        }

        public async Task<List<CustomerReview>> GetAllAsync()
        {
            return await _context.CustomerReviews
                .OrderByDescending(x => x.ReviewDate)
                .ToListAsync();
        }

        public async Task<CustomerReview?> GetByIdAsync(int id)
        {
            return await _context.CustomerReviews
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<CustomerReview>> GetByUserIdAsync(string userId)
        {
            return await _context.CustomerReviews
                .Where(x => x.CustomerId == userId)
                .OrderByDescending(x => x.ReviewDate)
                .ToListAsync();
        }

        public async Task<List<CustomerReview>> GetByProductIdAsync(string productId)
        {
            return await _context.CustomerReviews
                .Where(x => x.ProductId == productId)
                .OrderByDescending(x => x.ReviewDate)
                .ToListAsync();
        }

        public async Task<List<CustomerReview>> GetByYearAsync(int year)
        {
            return await _context.CustomerReviews
                .Where(x => x.ReviewDate.Year == year)
                .OrderByDescending(x => x.ReviewDate)
                .ToListAsync();
        }

        public async Task<CustomerReview> CreateAsync(CustomerReview review)
        {
            _context.CustomerReviews.Add(review);

            await _context.SaveChangesAsync();

            return review;
        }

        public async Task<CustomerReview?> UpdateAsync(CustomerReview review)
        {
            var existingReview = await _context.CustomerReviews
                .FirstOrDefaultAsync(x => x.Id == review.Id);

            if (existingReview == null)
            {
                return null;
            }

            existingReview.CustomerId = review.CustomerId;
            existingReview.CustomerName = review.CustomerName;
            existingReview.OrderId = review.OrderId;
            existingReview.OrderDate = review.OrderDate;
            existingReview.ProductId = review.ProductId;
            existingReview.ProductName = review.ProductName;
            existingReview.RatingValue = review.RatingValue;
            existingReview.Comment = review.Comment;
            existingReview.ReviewDate = review.ReviewDate;
            existingReview.Status = review.Status;

            await _context.SaveChangesAsync();

            return existingReview;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var review = await _context.CustomerReviews
                .FirstOrDefaultAsync(x => x.Id == id);

            if (review == null)
            {
                return false;
            }

            _context.CustomerReviews.Remove(review);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ApproveAsync(int id)
        {
            var review = await _context.CustomerReviews
                .FirstOrDefaultAsync(x => x.Id == id);

            if (review == null)
            {
                return false;
            }

            review.Status = "Approved";

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RejectAsync(int id)
        {
            var review = await _context.CustomerReviews
                .FirstOrDefaultAsync(x => x.Id == id);

            if (review == null)
            {
                return false;
            }

            review.Status = "Rejected";

            await _context.SaveChangesAsync();

            return true;
        }
    }
}