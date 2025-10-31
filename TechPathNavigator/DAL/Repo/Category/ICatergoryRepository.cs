using TechPathNavigator.DAL.Repositories.Generic;
using TechPathNavigator.Models;

namespace TechPathNavigator.Repositories
{
    /// <summary>
    /// Category repository interface
    /// Extends generic repository with custom operations
    /// </summary>
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<IEnumerable<Category>> GetCategoriesWithSubCategoryCountAsync();
    }
}
