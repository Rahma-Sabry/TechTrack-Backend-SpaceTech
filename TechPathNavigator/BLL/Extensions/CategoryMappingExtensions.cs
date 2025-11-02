using TechPathNavigator.DTOs;
using TechPathNavigator.Models;

namespace TechPathNavigator.Extensions
{
    public static class CategoryMappingExtensions
    {
        // Map Category entity to CategoryGetDto
        public static CategoryGetDto ToGetDto(this Category category)
        {
            return new CategoryGetDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description
            };
        }

        // Map CategoryPostDto to Category entity
        public static Category ToEntity(this CategoryPostDto dto, int? id = null)
        {
            return new Category
            {
                CategoryId = id ?? 0, // use id if updating
                CategoryName = dto.Name ?? string.Empty,
                Description = dto.Description ?? string.Empty
            };
        }
    }
}
