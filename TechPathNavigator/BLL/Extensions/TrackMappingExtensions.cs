using TechPathNavigator.DTOs;
using TechPathNavigator.Models;

namespace TechPathNavigator.Extensions
{
    public static class TrackMappingExtensions
    {
        // Entity → GetDto
        public static TrackGetDto ToGetDto(this Track track)
        {
            return new TrackGetDto
            {
                TrackId = track.TrackId,
                SubCategoryId = track.SubCategoryId,
                TrackName = track.TrackName,
                Description = track.Description,
                DifficultyLevel = track.DifficultyLevel,
                EstimatedDuration = track.EstimatedDuration
            };
        }

        // PostDto → Entity
        public static Track ToEntity(this TrackPostDto dto, int? id = null)
        {
            return new Track
            {
                TrackId = id ?? 0, // Use id if updating
                SubCategoryId = dto.SubCategoryId,
                TrackName = dto.TrackName,
                Description = dto.Description,
                DifficultyLevel = dto.DifficultyLevel,
                EstimatedDuration = dto.EstimatedDuration
            };
        }
    }
}
