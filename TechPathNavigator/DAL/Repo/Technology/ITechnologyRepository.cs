using TechPathNavigator.Models;

namespace TechPathNavigator.Repositories
{
    public interface ITechnologyRepository
    {
        Task<IEnumerable<Technology>> GetAllAsync();
        Task<Technology?> GetByIdAsync(int id);
        Task<IEnumerable<Technology>> GetBySubCategoryIdAsync(int subCategoryId);
        Task<Technology> AddAsync(Technology technology);
        Task<Technology?> UpdateAsync(Technology technology);
        Task<bool> DeleteAsync(int id);
    }
}
