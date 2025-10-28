using Microsoft.EntityFrameworkCore;
using TechPathNavigator.Data;
using TechPathNavigator.Models;
using TechPathNavigator.DTOs;

namespace TechPathNavigator.Services
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET ALL - Returns list of CategoryGetDto
        public async Task<IEnumerable<CategoryGetDto>> GetAllCategoriesAsync()
        {
            try
            {
                var categories = await _context.Categories.ToListAsync();

                return categories.Select(c => new CategoryGetDto
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    Description = c.Description
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve categories from database", ex);
            }
        }

        // GET BY ID - Returns single CategoryGetDto or null
        public async Task<CategoryGetDto?> GetCategoryByIdAsync(int id)
        {
            try
            {
                var category = await _context.Categories.FindAsync(id);

                if (category == null) return null;

                return new CategoryGetDto
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    Description = category.Description
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve category with ID {id}", ex);
            }
        }

        // CREATE - Takes CategoryPostDto, returns CategoryGetDto
        public async Task<CategoryGetDto> CreateCategoryAsync(CategoryPostDto dto)
        {
            try
            {
                var category = new Category
                {
                    CategoryName = dto.Name ?? string.Empty,
                    Description = dto.Description ?? string.Empty
                };

                _context.Categories.Add(category);
                await _context.SaveChangesAsync();

                return new CategoryGetDto
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    Description = category.Description
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create category", ex);
            }
        }

        // UPDATE - Takes CategoryPostDto, returns updated CategoryGetDto or null
        public async Task<CategoryGetDto?> UpdateCategoryAsync(int id, CategoryPostDto dto)
        {
            try
            {
                var category = await _context.Categories.FindAsync(id);

                if (category == null) return null;

                category.CategoryName = dto.Name ?? category.CategoryName;
                category.Description = dto.Description ?? category.Description;

                await _context.SaveChangesAsync();

                return new CategoryGetDto
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    Description = category.Description
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update category with ID {id}", ex);
            }
        }

        // DELETE - Returns true if deleted, false if not found
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            try
            {
                var category = await _context.Categories.FindAsync(id);

                if (category == null) return false;

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete category with ID {id}", ex);
            }
        }
    }
}