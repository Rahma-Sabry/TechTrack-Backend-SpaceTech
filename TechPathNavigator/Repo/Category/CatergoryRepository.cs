using Microsoft.EntityFrameworkCore;
using TechPathNavigator.Data;
using TechPathNavigator.Models;
namespace TechPathNavigator.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly ApplicationDbContext _context;
		public CategoryRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<Category>> GetAllAsync()
		{
			return await _context.Categories
				.Include(c => c.SubCategories)
				.AsNoTracking()
				.ToListAsync();
		}
		public async Task<Category?> GetByIdAsync(int id)
		{
			return await _context.Categories
				.Include(c => c.SubCategories)
				.FirstOrDefaultAsync(c => c.CategoryId == id);
		}
		public async Task<Category> AddAsync(Category category)
		{
			_context.Categories.Add(category);
			await _context.SaveChangesAsync();
			return category;
		}
		public async Task<Category?> UpdateAsync(Category category)
		{
			var existing = await _context.Categories.FindAsync(category.CategoryId);
			if (existing == null) return null;
			existing.Name = category.Name;
			existing.Description = category.Description;
			existing.ParentCategoryId = category.ParentCategoryId;
			await _context.SaveChangesAsync();
			return existing;
		}
		public async Task<bool> DeleteAsync(int id)
		{
			var category = await _context.Categories.FindAsync(id);
			if (category == null) return false;
			_context.Categories.Remove(category);
			await _context.SaveChangesAsync();
			return true;
		}
		public async Task<IEnumerable<Category>> GetSubCategoriesAsync(int parentCategoryId)
		{
			return await _context.Categories
				.Where(c => c.ParentCategoryId == parentCategoryId)
				.ToListAsync();
		}
		public async Task<IEnumerable<Roadmap>> GetRoadmapsByCategoryIdAsync(int categoryId)
		{
			return await _context.Roadmaps
				.Where(r => r.CategoryId == categoryId)
				.ToListAsync();
		}
	}
}