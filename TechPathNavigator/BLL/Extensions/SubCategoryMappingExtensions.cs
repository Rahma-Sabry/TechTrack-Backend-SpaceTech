using TechPathNavigator.DTOs;
using TechPathNavigator.Models;

namespace TechPathNavigator.Extensions
{
    public static class SubCategoryMappingExtensions
    {
        // Entity → GetDto
        public static SubCategoryGetDto ToGetDto(this SubCategory sc)
        {
            return new SubCategoryGetDto
            {
                SubCategoryId = sc.SubCategoryId,
                SubCategoryName = sc.SubCategoryName,
                Description = sc.Description,
                CategoryId = sc.CategoryId
            };
        }

        // PostDto → Entity
        public static SubCategory ToEntity(this SubCategoryPostDto dto, int? id = null)
        {
            return new SubCategory
            {
                SubCategoryId = id ?? 0,
                SubCategoryName = dto.SubCategoryName ?? string.Empty,
                Description = dto.Description ?? string.Empty,
                CategoryId = dto.CategoryId ?? 0,           // int? -> int
                DifficultyLevel = dto.DifficultyLevel ?? 0, // int? -> int
                EstimatedDuration = dto.EstimatedDuration ?? 0, // int? -> int
                ImageUrl = dto.ImageUrl
            };
        }



    }
}
