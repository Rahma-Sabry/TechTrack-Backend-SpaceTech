using TechPathNavigator.Common.Errors;
using TechPathNavigator.DTOs;
using TechPathNavigator.Extensions;
using TechPathNavigator.Models;
using TechPathNavigator.Repositories;

namespace TechPathNavigator.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository ?? throw new ArgumentNullException(nameof(subCategoryRepository));
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
                DifficultyLevel = (int)sc.DifficultyLevel,
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
                DifficultyLevel = (int)sc.DifficultyLevel,
                EstimatedDuration = sc.EstimatedDuration,
                ImageUrl = sc.ImageUrl
            };
        }

        public async Task<SubCategoryGetDto> AddAsync(SubCategoryPostDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.SubCategoryName))
                throw new ArgumentException(ErrorMessages.SubCategory_NameRequired);

            var entity = dto.ToEntity(); // Make sure your ToEntity() maps nullable ints properly
            var added = await _subCategoryRepository.AddAsync(entity);

            return new SubCategoryGetDto
            {
                SubCategoryId = added.SubCategoryId,
                SubCategoryName = added.SubCategoryName,
                Description = added.Description,
                CategoryId = added.CategoryId,
                DifficultyLevel = (int)added.DifficultyLevel,
                EstimatedDuration = added.EstimatedDuration,
                ImageUrl = added.ImageUrl
            };
        }

        public async Task<SubCategoryGetDto?> UpdateAsync(int id, SubCategoryPostDto dto)
        {
            var existing = await _subCategoryRepository.GetByIdAsync(id);
            if (existing == null) return null;

            // Only assign matching types
            existing.CategoryId = dto.CategoryId ?? existing.CategoryId;
            existing.DifficultyLevel = dto.DifficultyLevel ?? existing.DifficultyLevel;
            existing.EstimatedDuration = dto.EstimatedDuration ?? existing.EstimatedDuration;
            existing.SubCategoryName = dto.SubCategoryName ?? existing.SubCategoryName;
            existing.Description = dto.Description ?? existing.Description;
            existing.ImageUrl = dto.ImageUrl ?? existing.ImageUrl;


            var updated = await _subCategoryRepository.UpdateAsync(existing);
            if (updated == null) return null;

            return new SubCategoryGetDto
            {
                SubCategoryId = updated.SubCategoryId,
                SubCategoryName = updated.SubCategoryName,
                Description = updated.Description,
                CategoryId = updated.CategoryId,
                DifficultyLevel = (int)updated.DifficultyLevel,
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
                DifficultyLevel = (int)sc.DifficultyLevel,
                EstimatedDuration = sc.EstimatedDuration,
                ImageUrl = sc.ImageUrl
            });
        }
    }
}
