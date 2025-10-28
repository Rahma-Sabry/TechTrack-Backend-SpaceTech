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
                CategoryId = sc.CategoryId
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
                CategoryId = sc.CategoryId
            };
        }

        public async Task<SubCategoryGetDto> AddAsync(SubCategoryPostDto subCategoryDto)
        {
            var subCategory = new SubCategory
            {
                SubCategoryName = subCategoryDto.SubCategoryName,
                Description = subCategoryDto.Description,
                CategoryId = subCategoryDto.CategoryId
            };

            var added = await _subCategoryRepository.AddAsync(subCategory);

            return new SubCategoryGetDto
            {
                SubCategoryId = added.SubCategoryId,
                SubCategoryName = added.SubCategoryName,
                Description = added.Description,
                CategoryId = added.CategoryId
            };
        }

        public async Task<SubCategoryGetDto?> UpdateAsync(int id, SubCategoryPostDto subCategoryDto)
        {
            var subCategory = new SubCategory
            {
                SubCategoryId = id,
                SubCategoryName = subCategoryDto.SubCategoryName,
                Description = subCategoryDto.Description,
                CategoryId = subCategoryDto.CategoryId
            };

            var updated = await _subCategoryRepository.UpdateAsync(subCategory);
            if (updated == null) return null;

            return new SubCategoryGetDto
            {
                SubCategoryId = updated.SubCategoryId,
                SubCategoryName = updated.SubCategoryName,
                Description = updated.Description,
                CategoryId = updated.CategoryId
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
                CategoryId = sc.CategoryId
            });
        }
    }
}
