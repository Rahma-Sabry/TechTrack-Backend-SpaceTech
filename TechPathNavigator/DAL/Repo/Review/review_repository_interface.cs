using TechPathNavigator.Models;

namespace TechPathNavigator.Repositories
{
    public interface IUserTechnologyReviewRepository:  IGenericRepository<UserTechnologyReview>
    {
        //Task<IEnumerable<UserTechnologyReview>> GetAllAsync();
        //Task<UserTechnologyReview?> GetByIdAsync(int id);
        Task<IEnumerable<UserTechnologyReview>> GetByUserIdAsync(int userId);
        Task<IEnumerable<UserTechnologyReview>> GetByTechnologyIdAsync(int technologyId);
        //Task<UserTechnologyReview> AddAsync(UserTechnologyReview review);
        //Task<UserTechnologyReview?> UpdateAsync(UserTechnologyReview review);
        //Task<bool> DeleteAsync(int id);
        Task<bool> UserExistsAsync(int userId);
        Task<bool> TechnologyExistsAsync(int technologyId);
    }
}
