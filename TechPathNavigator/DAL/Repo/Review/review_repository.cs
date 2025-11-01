using Microsoft.EntityFrameworkCore;
using TechPathNavigator.Data;
using TechPathNavigator.Models;

namespace TechPathNavigator.Repositories
{
    public class UserTechnologyReviewRepository : IUserTechnologyReviewRepository
    {
        private readonly ApplicationDbContext _context;

        public UserTechnologyReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserTechnologyReview>> GetAllAsync()
        {
            return await _context.UserTechnologyReviews
                .Include(r => r.User)
                .Include(r => r.Technology)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<UserTechnologyReview?> GetByIdAsync(int id)
        {
            return await _context.UserTechnologyReviews
                .Include(r => r.User)
                .Include(r => r.Technology)
                .FirstOrDefaultAsync(r => r.ReviewId == id);
        }

        public async Task<IEnumerable<UserTechnologyReview>> GetByUserIdAsync(int userId)
        {
            return await _context.UserTechnologyReviews
                .Include(r => r.Technology)
                .Where(r => r.UserId == userId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<UserTechnologyReview>> GetByTechnologyIdAsync(int technologyId)
        {
            return await _context.UserTechnologyReviews
                .Include(r => r.User)
                .Where(r => r.TechnologyId == technologyId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<UserTechnologyReview> AddAsync(UserTechnologyReview review)
        {
            _context.UserTechnologyReviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<UserTechnologyReview?> UpdateAsync(UserTechnologyReview review)
        {
            var existing = await _context.UserTechnologyReviews.FindAsync(review.ReviewId);
            if (existing == null) return null;

            existing.Rating = review.Rating;
            existing.ReviewText = review.ReviewText;
            existing.TechnologyId = review.TechnologyId;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var review = await _context.UserTechnologyReviews.FindAsync(id);
            if (review == null) return false;

            _context.UserTechnologyReviews.Remove(review);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UserExistsAsync(int userId)
        {
            return await _context.Users.AnyAsync(u => u.UserId == userId);
        }

        public async Task<bool> TechnologyExistsAsync(int technologyId)
        {
            return await _context.Technologies.AnyAsync(t => t.TechnologyId == technologyId);
        }
    }
}
