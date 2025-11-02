using TechPathNavigator.DTOs;
using TechPathNavigator.Models;
using TechPathNavigator.Repositories;

namespace TechPathNavigator.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        // GET ALL - Returns list of CategoryGetDto
        public async Task<IEnumerable<CategoryGetDto>> GetAllCategoriesAsync()
        {
            try
            {
                var categories = await _repo.GetAllAsync();

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
                var category = await _repo.GetByIdAsync(id);

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

                var createdCategory = await _repo.AddAsync(category);

                return new CategoryGetDto
                {
                    CategoryId = createdCategory.CategoryId,
                    CategoryName = createdCategory.CategoryName,
                    Description = createdCategory.Description
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
                var existingCategory = await _repo.GetByIdAsync(id);

                if (existingCategory == null) return null;

                existingCategory.CategoryName = dto.Name ?? existingCategory.CategoryName;
                existingCategory.Description = dto.Description ?? existingCategory.Description;

                var updatedCategory = await _repo.UpdateAsync(existingCategory);

                if (updatedCategory == null) return null;

                return new CategoryGetDto
                {
                    CategoryId = updatedCategory.CategoryId,
                    CategoryName = updatedCategory.CategoryName,
                    Description = updatedCategory.Description
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
                return await _repo.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete category with ID {id}", ex);
            }
        }
    }
}