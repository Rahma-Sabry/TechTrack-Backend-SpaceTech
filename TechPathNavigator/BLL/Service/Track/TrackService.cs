using TechPathNavigator.DTOs;
using TechPathNavigator.Models;
using TechPathNavigator.Repositories;
using TechPathNavigator.Service.Track;

namespace TechPathNavigator.Services
{
    public class TrackService : ITrackService
    {
        private readonly ITrackRepository _repo;

        public TrackService(ITrackRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<TrackGetDto>> GetAllAsync()
        {
            var tracks = await _repo.GetAllAsync();
            return tracks.Select(t => new TrackGetDto
            {
                TrackId = t.TrackId,
                SubCategoryId = t.SubCategoryId,
                TrackName = t.TrackName,
                Description = t.Description,
                DifficultyLevel = t.DifficultyLevel,
                EstimatedDuration = t.EstimatedDuration
            });
        }

        public async Task<TrackGetDto?> GetByIdAsync(int id)
        {
            var t = await _repo.GetByIdAsync(id);
            if (t == null) return null;

            return new TrackGetDto
            {
                TrackId = t.TrackId,
                SubCategoryId = t.SubCategoryId,
                TrackName = t.TrackName,
                Description = t.Description,
                DifficultyLevel = t.DifficultyLevel,
                EstimatedDuration = t.EstimatedDuration
            };
        }

        public async Task<TrackGetDto> AddAsync(TrackPostDto dto)
        {
            var entity = new Track
            {
                SubCategoryId = dto.SubCategoryId,
                TrackName = dto.TrackName,
                Description = dto.Description,
                DifficultyLevel = dto.DifficultyLevel,
                EstimatedDuration = dto.EstimatedDuration
            };

            var added = await _repo.AddAsync(entity);
            return new TrackGetDto
            {
                TrackId = added.TrackId,
                SubCategoryId = added.SubCategoryId,
                TrackName = added.TrackName,
                Description = added.Description,
                DifficultyLevel = added.DifficultyLevel,
                EstimatedDuration = added.EstimatedDuration
            };
        }

        public async Task<TrackGetDto?> UpdateAsync(int id, TrackPostDto dto)
        {
            var entity = new Track
            {
                TrackId = id,
                SubCategoryId = dto.SubCategoryId,
                TrackName = dto.TrackName,
                Description = dto.Description,
                DifficultyLevel = dto.DifficultyLevel,
                EstimatedDuration = dto.EstimatedDuration
            };

            var updated = await _repo.UpdateAsync(entity);
            if (updated == null) return null;

            return new TrackGetDto
            {
                TrackId = updated.TrackId,
                SubCategoryId = updated.SubCategoryId,
                TrackName = updated.TrackName,
                Description = updated.Description,
                DifficultyLevel = updated.DifficultyLevel,
                EstimatedDuration = updated.EstimatedDuration
            };
        }

        public async Task<bool> DeleteAsync(int id) => await _repo.DeleteAsync(id);
    }
}
