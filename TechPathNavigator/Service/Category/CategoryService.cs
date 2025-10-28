using TechPathNavigator.Data;
using TechPathNavigator.Models;

namespace TechPathNavigator.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }
        public Category? GetCategoryById(int id)
        {
            return _context.Categories.Find(id);
        }
        public Category CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }
        public Category? UpdateCategory(int id, Category updated)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return null;
            category.CategoryName = updated.CategoryName;
            category.Description = updated.Description;
            _context.SaveChanges();
            return category;
        }
        public bool DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return false;
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return true;
        }
    }
}