using TechPathNavigator.DTOs;
using TechPathNavigator.Models;

namespace TechPathNavigator.Extensions
{
    public static class TechnologyMappingExtensions
    {
        // Entity → GetDto
        public static TechnologyGetDto ToGetDto(this Technology tech)
        {
            return new TechnologyGetDto
            {
                TechnologyId = tech.TechnologyId,
                TrackId = tech.TrackId,
                TechnologyName = tech.TechnologyName,
                Description = tech.Description,
                VideoUrl = tech.VideoUrl,
                CreatedAt = tech.CreatedAt
            };
        }

        // PostDto → Entity
        public static Technology ToEntity(this TechnologyPostDto dto, int? id = null)
        {
            return new Technology
            {
                TechnologyId = id ?? 0, // use id if updating
                TrackId = dto.TrackId,
                TechnologyName = dto.TechnologyName,
                Description = dto.Description,
                VideoUrl = dto.VideoUrl
            };
        }
    }
}
