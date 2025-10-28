using TechPathNavigator.DTOs;
using TechPathNavigator.DTOs.Review;
using TechPathNavigator.Models;
using TechPathNavigator.Repositories;

namespace TechPathNavigator.Services
{
    public class UserTechnologyReviewService
    {
        private readonly IUserTechnologyReviewRepository _repo;

        public UserTechnologyReviewService(IUserTechnologyReviewRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<UserTechnologyReviewGetDto>> GetAllAsync()
        {
            var reviews = await _repo.GetAllAsync();
            return reviews.Select(r => new UserTechnologyReviewGetDto
            {
                ReviewId = r.ReviewId,
                UserId = r.UserId,
                TechnologyId = r.TechnologyId,
                Rating = r.Rating,
                ReviewText = r.ReviewText,
                UserName = r.User?.UserName,
                TechnologyName = r.Technology?.TechnologyName
            });
        }

        public async Task<UserTechnologyReviewGetDto?> GetByIdAsync(int id)
        {
            var review = await _repo.GetByIdAsync(id);
            if (review == null) return null;

            return new UserTechnologyReviewGetDto
            {
                ReviewId = review.ReviewId,
                UserId = review.UserId,
                TechnologyId = review.TechnologyId,
                Rating = review.Rating,
                ReviewText = review.ReviewText,
                UserName = review.User?.UserName,
                TechnologyName = review.Technology?.TechnologyName
            };
        }

        public async Task<IEnumerable<UserTechnologyReviewGetDto>> GetByUserIdAsync(int userId)
        {
            var reviews = await _repo.GetByUserIdAsync(userId);
            return reviews.Select(r => new UserTechnologyReviewGetDto
            {
                ReviewId = r.ReviewId,
                UserId = r.UserId,
                TechnologyId = r.TechnologyId,
                Rating = r.Rating,
                ReviewText = r.ReviewText,
                TechnologyName = r.Technology?.TechnologyName
            });
        }

        public async Task<IEnumerable<UserTechnologyReviewGetDto>> GetByTechnologyIdAsync(int technologyId)
        {
            var reviews = await _repo.GetByTechnologyIdAsync(technologyId);
            return reviews.Select(r => new UserTechnologyReviewGetDto
            {
                ReviewId = r.ReviewId,
                UserId = r.UserId,
                TechnologyId = r.TechnologyId,
                Rating = r.Rating,
                ReviewText = r.ReviewText,
                UserName = r.User?.UserName
            });
        }

        public async Task<UserTechnologyReviewGetDto> AddAsync(UserTechnologyReviewPostDto dto)
        {
            var entity = new UserTechnologyReview
            {
                UserId = dto.UserId,
                TechnologyId = dto.TechnologyId,
                Rating = dto.Rating,
                ReviewText = dto.ReviewText
            };

            var added = await _repo.AddAsync(entity);

            return new UserTechnologyReviewGetDto
            {
                ReviewId = added.ReviewId,
                UserId = added.UserId,
                TechnologyId = added.TechnologyId,
                Rating = added.Rating,
                ReviewText = added.ReviewText
            };
        }

        public async Task<UserTechnologyReviewGetDto?> UpdateAsync(int id, UserTechnologyReviewPostDto dto)
        {
            var entity = new UserTechnologyReview
            {
                ReviewId = id,
                UserId = dto.UserId,
                TechnologyId = dto.TechnologyId,
                Rating = dto.Rating,
                ReviewText = dto.ReviewText
            };

            var updated = await _repo.UpdateAsync(entity);
            if (updated == null) return null;

            return new UserTechnologyReviewGetDto
            {
                ReviewId = updated.ReviewId,
                UserId = updated.UserId,
                TechnologyId = updated.TechnologyId,
                Rating = updated.Rating,
                ReviewText = updated.ReviewText
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
