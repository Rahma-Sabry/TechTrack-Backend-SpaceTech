// ========================================
// Category.cs
// ========================================
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechPathNavigator.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required, MaxLength(200)]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        [MaxLength(500)]
        public string? ImageUrl { get; set; }

        // Navigation
        public ICollection<SubCategory> SubCategories { get; set; }
    }
}

// ========================================
// SubCategory.cs
// ========================================
using System.ComponentModel.DataAnnotations;

namespace TechPathNavigator.Models
{
    public class SubCategory
    {
        [Key]
        public int SubCategoryId { get; set; }
        public int CategoryId { get; set; }
        public string? SubCategoryName { get; set; }
        public string? Description { get; set; }
        public string? DifficultyLevel { get; set; }
        public int EstimatedDuration { get; set; }
        
        [MaxLength(500)]
        public string? ImageUrl { get; set; }
        
        public Category? Category { get; set; }
        public ICollection<Track>? Tracks { get; set; }
    }
}

// ========================================
// CategoryGetDto.cs
// ========================================
namespace TechPathNavigator.DTOs
{
    public class CategoryGetDto
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}

// ========================================
// CategoryPostDto.cs
// ========================================
namespace TechPathNavigator.DTOs
{
    public class CategoryPostDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}

// ========================================
// SubCategoryGetDto.cs
// ========================================
namespace TechPathNavigator.DTOs
{
    public class SubCategoryGetDto
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string Description { get; set; }
        public string DifficultyLevel { get; set; }
        public int EstimatedDuration { get; set; }
        public string? ImageUrl { get; set; }

        // Optional: Include Category info
        public int CategoryId { get; set; }
    }
}

// ========================================
// SubCategoryPostDto.cs
// ========================================
namespace TechPathNavigator.DTOs
{
    public class SubCategoryPostDto
    {
        public string SubCategoryName { get; set; }
        public string Description { get; set; }
        public string DifficultyLevel { get; set; }
        public int EstimatedDuration { get; set; }
        public int CategoryId { get; set; }
        public string? ImageUrl { get; set; }
    }
}

// ========================================
// CategoryService.cs
// ========================================
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
                throw new Exception("Failed to retrieve categories from database", ex);
            }
        }

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
                throw new Exception($"Failed to retrieve category with ID {id}", ex);
            }
        }

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
                throw new Exception("Failed to create category", ex);
            }
        }

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
                throw new Exception($"Failed to update category with ID {id}", ex);
            }
        }

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

// ========================================
// SubCategoryService.cs
// ========================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechPathNavigator.DTOs;
using TechPathNavigator.Models;
using TechPathNavigator.Repositories;

namespace TechPathNavigator.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public async Task<IEnumerable<SubCategoryGetDto>> GetAllAsync()
        {
            var subCategories = await _subCategoryRepository.GetAllAsync();

            return subCategories.Select(sc => new SubCategoryGetDto
            {
                SubCategoryId = sc.SubCategoryId,
                SubCategoryName = sc.SubCategoryName,
                Description = sc.Description,
                CategoryId = sc.CategoryId,
                DifficultyLevel = sc.DifficultyLevel,
                EstimatedDuration = sc.EstimatedDuration,
                ImageUrl = sc.ImageUrl
            });
        }

        public async Task<SubCategoryGetDto?> GetByIdAsync(int id)
        {
            var sc = await _subCategoryRepository.GetByIdAsync(id);
            if (sc == null) return null;

            return new SubCategoryGetDto
            {
                SubCategoryId = sc.SubCategoryId,
                SubCategoryName = sc.SubCategoryName,
                Description = sc.Description,
                CategoryId = sc.CategoryId,
                DifficultyLevel = sc.DifficultyLevel,
                EstimatedDuration = sc.EstimatedDuration,
                ImageUrl = sc.ImageUrl
            };
        }

        public async Task<SubCategoryGetDto> AddAsync(SubCategoryPostDto subCategoryDto)
        {
            var subCategory = new SubCategory
            {
                SubCategoryName = subCategoryDto.SubCategoryName,
                Description = subCategoryDto.Description,
                CategoryId = subCategoryDto.CategoryId,
                DifficultyLevel = subCategoryDto.DifficultyLevel,
                EstimatedDuration = subCategoryDto.EstimatedDuration,
                ImageUrl = subCategoryDto.ImageUrl
            };

            var added = await _subCategoryRepository.AddAsync(subCategory);

            return new SubCategoryGetDto
            {
                SubCategoryId = added.SubCategoryId,
                SubCategoryName = added.SubCategoryName,
                Description = added.Description,
                CategoryId = added.CategoryId,
                DifficultyLevel = added.DifficultyLevel,
                EstimatedDuration = added.EstimatedDuration,
                ImageUrl = added.ImageUrl
            };
        }

        public async Task<SubCategoryGetDto?> UpdateAsync(int id, SubCategoryPostDto subCategoryDto)
        {
            var subCategory = new SubCategory
            {
                SubCategoryId = id,
                SubCategoryName = subCategoryDto.SubCategoryName,
                Description = subCategoryDto.Description,
                CategoryId = subCategoryDto.CategoryId,
                DifficultyLevel = subCategoryDto.DifficultyLevel,
                EstimatedDuration = subCategoryDto.EstimatedDuration,
                ImageUrl = subCategoryDto.ImageUrl
            };

            var updated = await _subCategoryRepository.UpdateAsync(subCategory);
            if (updated == null) return null;

            return new SubCategoryGetDto
            {
                SubCategoryId = updated.SubCategoryId,
                SubCategoryName = updated.SubCategoryName,
                Description = updated.Description,
                CategoryId = updated.CategoryId,
                DifficultyLevel = updated.DifficultyLevel,
                EstimatedDuration = updated.EstimatedDuration,
                ImageUrl = updated.ImageUrl
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _subCategoryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SubCategoryGetDto>> GetByCategoryIdAsync(int categoryId)
        {
            var subCategories = await _subCategoryRepository.GetByCategoryIdAsync(categoryId);

            return subCategories.Select(sc => new SubCategoryGetDto
            {
                SubCategoryId = sc.SubCategoryId,
                SubCategoryName = sc.SubCategoryName,
                Description = sc.Description,
                CategoryId = sc.CategoryId,
                DifficultyLevel = sc.DifficultyLevel,
                EstimatedDuration = sc.EstimatedDuration,
                ImageUrl = sc.ImageUrl
            });
        }
    }
}

// ========================================
// CategoryRepository.cs (Update UpdateAsync method)
// ========================================
public async Task<Category?> UpdateAsync(Category category)
{
    var existing = await _context.Categories.FindAsync(category.CategoryId);
    if (existing == null) return null;

    existing.CategoryName = category.CategoryName;
    existing.Description = category.Description;
    existing.ImageUrl = category.ImageUrl;

    await _context.SaveChangesAsync();
    return existing;
}

// ========================================
// SubCategoryRepository.cs (Update UpdateAsync method)
// ========================================
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