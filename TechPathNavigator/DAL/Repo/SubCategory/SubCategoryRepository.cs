using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechPathNavigator.Models;
using TechPathNavigator.Data;

namespace TechPathNavigator.Repositories
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public SubCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SubCategory>> GetAllAsync()
        {
            return await _context.SubCategories
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<SubCategory?> GetByIdAsync(int id)
        {
            return await _context.SubCategories
                .FirstOrDefaultAsync(sc => sc.SubCategoryId == id);
        }
        public async Task<SubCategory> AddAsync(SubCategory subCategory)
        {
            _context.SubCategories.Add(subCategory);
            await _context.SaveChangesAsync();
            return subCategory;
        }
        public async Task<SubCategory?> UpdateAsync(SubCategory subCategory)
        {
            var existing = await _context.SubCategories.FindAsync(subCategory.SubCategoryId);
            if (existing == null) return null;
            existing.SubCategoryName = subCategory.SubCategoryName;
            existing.Description = subCategory.Description;
            existing.CategoryId = subCategory.CategoryId;
            existing.DifficultyLevel = subCategory.DifficultyLevel;
            existing.EstimatedDuration = subCategory.EstimatedDuration;
            existing.ImageUrl = subCategory.ImageUrl;
            await _context.SaveChangesAsync();
            return existing;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var subCategory = await _context.SubCategories.FindAsync(id);
            if (subCategory == null) return false;
            _context.SubCategories.Remove(subCategory);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<SubCategory>> GetByCategoryIdAsync(int categoryId)
        {
            return await _context.SubCategories
                .Where(sc => sc.CategoryId == categoryId)
                .ToListAsync();
        }
    }
}