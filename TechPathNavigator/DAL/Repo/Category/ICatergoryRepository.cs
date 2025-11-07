using TechPathNavigator.Models;

namespace TechPathNavigator.Repositories
    {
    public interface ICategoryRepository : IGenericRepository<Category>
    {
      /*  Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<Category> AddAsync(Category category);
        Task<Category?> UpdateAsync(Category category);
        Task<bool> DeleteAsync(int id); */
    }
}