using Microsoft.EntityFrameworkCore;
using TechPathNavigator.DAL.Repositories.Generic;
using TechPathNavigator.DAL.Data;
using TechPathNavigator.Models;

namespace TechPathNavigator.Repositories
{
    /// <summary>
    /// Category repository with custom operations
    /// Inherits from GenericRepository for common CRUD
    /// </summary>
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Override to include subcategories in the query
        /// </summary>
        public override async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _dbSet
                .Include(c => c.SubCategories)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Override to include subcategories when fetching by ID
        /// </summary>
        public override async Task<Category?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(c => c.SubCategories)
                .FirstOrDefaultAsync(c => c.CategoryId == id);
        }

        /// <summary>
        /// Custom method: Get categories with technology count
        /// </summary>
        public async Task<IEnumerable<Category>> GetCategoriesWithSubCategoryCountAsync()
        {
            return await _dbSet
                .Include(c => c.SubCategories)
                .Select(c => new Category
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    Description = c.Description,
                    SubCategories = c.SubCategories
                })
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
