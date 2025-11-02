using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechPathNavigator.DTOs;
using TechPathNavigator.Extensions;
using TechPathNavigator.Repositories;
using TechPathNavigator.Common.Errors;

namespace TechPathNavigator.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        // Get all categories
        public async Task<IEnumerable<CategoryGetDto>> GetAllCategoriesAsync()
        {
            var categories = await _repo.GetAllAsync();
            return categories.Select(c => c.ToGetDto());
        }

        // Get category by ID
        public async Task<CategoryGetDto?> GetCategoryByIdAsync(int id)
        {
            var category = await _repo.GetByIdAsync(id);
            return category?.ToGetDto();
        }

        // Create a new category
        public async Task<CategoryGetDto> CreateCategoryAsync(CategoryPostDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentException(ErrorMessages.Company_NameRequired);

            var entity = dto.ToEntity();
            var created = await _repo.AddAsync(entity);
            return created.ToGetDto();
        }

        // Update an existing category
        public async Task<CategoryGetDto?> UpdateCategoryAsync(int id, CategoryPostDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return null;

            existing.CategoryName = dto.Name ?? existing.CategoryName;
            existing.Description = dto.Description ?? existing.Description;

            var updated = await _repo.UpdateAsync(existing);
            return updated?.ToGetDto();
        }

        // Delete a category
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
