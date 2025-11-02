using TechPathNavigator.DTOs;
using TechPathNavigator.Models;

namespace TechPathNavigator.Extensions
{
    public static class RoadmapMappingExtensions
    {
        // Map Roadmap entity to RoadmapGetDto
        public static RoadmapGetDto ToGetDto(this Roadmap roadmap)
        {
            return new RoadmapGetDto
            {
                RoadmapId = roadmap.RoadmapId,
                TrackId = roadmap.TrackId,
                Title = roadmap.Title,
                Description = roadmap.Description,
                RoadmapSteps = roadmap.RoadmapSteps?.Select(s => s.ToGetDto()).ToList()
            };
        }

        // Map RoadmapPostDto to Roadmap entity
        public static Roadmap ToEntity(this RoadmapPostDto dto, int? id = null)
        {
            return new Roadmap
            {
                RoadmapId = id ?? 0, // use id if updating
                TrackId = dto.TrackId,
                Title = dto.Title,
                Description = dto.Description
            };
        }
    }
}
