using AutoMapper;
using FluentValidation;
using TechPathNavigator.DTOs;
using TechPathNavigator.Extensions;
using TechPathNavigator.Models;
using TechPathNavigator.Repositories;

namespace TechPathNavigator.Services
{
    /// <summary>
    /// Category service with AutoMapper and FluentValidation integration
    /// Follows clean architecture principles
    /// </summary>
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<CategoryPostDto> _validator;

        public CategoryService(
            ICategoryRepository repository,
            IMapper mapper,
            IValidator<CategoryPostDto> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<IEnumerable<CategoryGetDto>> GetAllCategoriesAsync()
        {
            var categories = await _repository.GetAllAsync();
            return _mapper.MapList<Category, CategoryGetDto>(categories);
        }

        public async Task<CategoryGetDto?> GetCategoryByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            return _mapper.MapOrDefault<Category, CategoryGetDto>(category);
        }

        public async Task<CategoryGetDto> CreateCategoryAsync(CategoryPostDto dto)
        {
            // Validate using FluentValidation
            var validationResult = await _validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            // Map DTO to Entity using AutoMapper
            var category = _mapper.Map<Category>(dto);

            var created = await _repository.AddAsync(category);
            return _mapper.Map<CategoryGetDto>(created);
        }

        public async Task<CategoryGetDto?> UpdateCategoryAsync(int id, CategoryPostDto dto)
        {
            var validationResult = await _validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            var updated = await _repository.UpdateAsync(existing);

            return _mapper.MapOrDefault<Category, CategoryGetDto>(updated);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
