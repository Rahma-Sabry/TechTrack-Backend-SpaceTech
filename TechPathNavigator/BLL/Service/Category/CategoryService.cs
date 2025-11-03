using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechPathNavigator.Common.Errors;
using TechPathNavigator.DTOs;
using TechPathNavigator.Extensions;
using TechPathNavigator.Models;
using TechPathNavigator.Repositories;

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
            try
            {
                var categories = await _repo.GetAllAsync();

                return categories.Select(c => new CategoryGetDto
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorMessages.Category_FetchFailed, ex);
            }
        }

        // Get category by ID
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
                    Description = category.Description,
                    ImageUrl = category.ImageUrl
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorMessages.Category_FetchByIdFailed, ex);
            }
        }

        // Create a new category
        public async Task<CategoryGetDto> CreateCategoryAsync(CategoryPostDto dto)
        {
            try
            {
                var category = new Category
                {
                    CategoryName = dto.Name ?? string.Empty,
                    Description = dto.Description ?? string.Empty,
                    ImageUrl = dto.ImageUrl
                };

                var createdCategory = await _repo.AddAsync(category);

                return new CategoryGetDto
                {
                    CategoryId = createdCategory.CategoryId,
                    CategoryName = createdCategory.CategoryName,
                    Description = createdCategory.Description,
                    ImageUrl = createdCategory.ImageUrl
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorMessages.Category_CreateFailed, ex);
            }
        }

        // Update an existing category
        public async Task<CategoryGetDto?> UpdateCategoryAsync(int id, CategoryPostDto dto)
        {
            try
            {
                var existingCategory = await _repo.GetByIdAsync(id);
                if (existingCategory == null) return null;

                existingCategory.CategoryName = dto.Name ?? existingCategory.CategoryName;
                existingCategory.Description = dto.Description ?? existingCategory.Description;
                existingCategory.ImageUrl = dto.ImageUrl ?? existingCategory.ImageUrl;

                var updatedCategory = await _repo.UpdateAsync(existingCategory);
                if (updatedCategory == null) return null;

                return new CategoryGetDto
                {
                    CategoryId = updatedCategory.CategoryId,
                    CategoryName = updatedCategory.CategoryName,
                    Description = updatedCategory.Description,
                    ImageUrl = updatedCategory.ImageUrl
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorMessages.Category_UpdateFailed, ex);
            }
        }

        // Delete a category
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            try
            {
                return await _repo.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorMessages.Category_DeleteFailed, ex);
            }
        }
    }
}
