using TechPathNavigator.Common.Errors;
using TechPathNavigator.Common.Messages;
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
            return subCategories.Select(sc => sc.ToGetDto());
        }

        public async Task<SubCategoryGetDto?> GetByIdAsync(int id)
        {
            var sc = await _subCategoryRepository.GetByIdAsync(id);
            return sc?.ToGetDto();
        }

        public async Task<SubCategoryGetDto> AddAsync(SubCategoryPostDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.SubCategoryName))
                throw new ArgumentException(ErrorMessages.SubCategory_NameRequired);

            var entity = dto.ToEntity();
            var added = await _subCategoryRepository.AddAsync(entity);
            return added.ToGetDto(); // Not nullable because AddAsync guarantees a result
        }

        public async Task<SubCategoryGetDto?> UpdateAsync(int id, SubCategoryPostDto dto)
        {
            var existing = await _subCategoryRepository.GetByIdAsync(id);
            if (existing == null) return null;

            existing.SubCategoryName = dto.SubCategoryName ?? existing.SubCategoryName;
            existing.CategoryId = dto.CategoryId != 0 ? dto.CategoryId : existing.CategoryId;

            var updated = await _subCategoryRepository.UpdateAsync(existing);
            return updated?.ToGetDto(); // Nullable because update might fail
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _subCategoryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SubCategoryGetDto>> GetByCategoryIdAsync(int categoryId)
        {
            var subCategories = await _subCategoryRepository.GetByCategoryIdAsync(categoryId);
            return subCategories.Select(sc => sc.ToGetDto());
        }
    }
}
