using TechPathNavigator.Models;

namespace TechPathNavigator.Repositories
    {
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<Category> AddAsync(Category category);
        Task<Category?> UpdateAsync(Category category);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Category>> GetSubCategoriesAsync(int parentCategoryId);
        Task<IEnumerable<Roadmap>> GetRoadmapsByCategoryIdAsync(int categoryId);
    }
}