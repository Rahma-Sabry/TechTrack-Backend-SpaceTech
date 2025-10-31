using TechPathNavigator.Common.Errors;
using TechPathNavigator.Common.Results;
using TechPathNavigator.DTOs;
using TechPathNavigator.DTOs.Review;
using TechPathNavigator.Extensions;
using TechPathNavigator.Models;
using TechPathNavigator.Repositories;

namespace TechPathNavigator.Services
{
    public class UserTechnologyReviewService : IUserTechnologyReviewService
    {
        private readonly IUserTechnologyReviewRepository _repo;

        public UserTechnologyReviewService(IUserTechnologyReviewRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<UserTechnologyReviewGetDto>> GetAllAsync()
        {
            var reviews = await _repo.GetAllAsync();
            return reviews.Select(r => r.ToGetDto());
        }

        public async Task<UserTechnologyReviewGetDto?> GetByIdAsync(int id)
        {
            var review = await _repo.GetByIdAsync(id);
            if (review == null) return null;

            return review.ToGetDto();
        }

        public async Task<IEnumerable<UserTechnologyReviewGetDto>> GetByUserIdAsync(int userId)
        {
            var reviews = await _repo.GetByUserIdAsync(userId);
            return reviews.Select(r => r.ToGetDto());
        }

        public async Task<IEnumerable<UserTechnologyReviewGetDto>> GetByTechnologyIdAsync(int technologyId)
        {
            var reviews = await _repo.GetByTechnologyIdAsync(technologyId);
            return reviews.Select(r => r.ToGetDto());
        }

        public async Task<ServiceResult<UserTechnologyReviewGetDto>> AddAsync(UserTechnologyReviewPostDto dto)
        {
            var errors = await Validate(dto);
            if (errors.Any()) return ServiceResult<UserTechnologyReviewGetDto>.Fail(errors);

            var added = await _repo.AddAsync(dto.ToEntity());
            return ServiceResult<UserTechnologyReviewGetDto>.Ok(added.ToGetDto());
        }

        public async Task<ServiceResult<UserTechnologyReviewGetDto>> UpdateAsync(int id, UserTechnologyReviewPostDto dto)
        {
            var errors = await Validate(dto);
            if (errors.Any()) return ServiceResult<UserTechnologyReviewGetDto>.Fail(errors);

            var updated = await _repo.UpdateAsync(dto.ToEntity(id));
            if (updated == null) return ServiceResult<UserTechnologyReviewGetDto>.Fail("Review not found.");

            return ServiceResult<UserTechnologyReviewGetDto>.Ok(updated.ToGetDto());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        private async Task<List<string>> Validate(UserTechnologyReviewPostDto dto)
        {
            var errors = new List<string>();
            if (dto.Rating < 1 || dto.Rating > 5)
            {
                errors.Add(ErrorMessages.Review_RatingInvalid);
            }
            if (!await _repo.UserExistsAsync(dto.UserId))
            {
                errors.Add(ErrorMessages.Review_UserInvalid);
            }
            if (!await _repo.TechnologyExistsAsync(dto.TechnologyId))
            {
                errors.Add(ErrorMessages.Review_TechnologyInvalid);
            }
            return errors;
        }
    }
}
