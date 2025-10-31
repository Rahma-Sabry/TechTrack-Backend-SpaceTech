using TechPathNavigator.Common.Results;
using TechPathNavigator.DTOs.Review;

namespace TechPathNavigator.Services
{
    public interface IUserTechnologyReviewService
    {
        Task<IEnumerable<UserTechnologyReviewGetDto>> GetAllAsync();
        Task<UserTechnologyReviewGetDto?> GetByIdAsync(int id);
        Task<IEnumerable<UserTechnologyReviewGetDto>> GetByUserIdAsync(int userId);
        Task<IEnumerable<UserTechnologyReviewGetDto>> GetByTechnologyIdAsync(int technologyId);
        Task<ServiceResult<UserTechnologyReviewGetDto>> AddAsync(UserTechnologyReviewPostDto dto);
        Task<ServiceResult<UserTechnologyReviewGetDto>> UpdateAsync(int id, UserTechnologyReviewPostDto dto);
        Task<bool> DeleteAsync(int id);
    }
}


