using TechPathNavigator.DTOs;
using TechPathNavigator.Models;
using TechPathNavigator.Repositories;

namespace TechPathNavigator.Services
{
    public class TechnologyService
    {
        private readonly ITechnologyRepository _repo;

        public TechnologyService(ITechnologyRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<TechnologyGetDto>> GetAllAsync()
        {
            var techs = await _repo.GetAllAsync();

            return techs.Select(t => new TechnologyGetDto
            {
                TechnologyId = t.TechnologyId,
                TrackId = t.TrackId,
                TechnologyName = t.TechnologyName,
                Description = t.Description,
                VideoUrl = t.VideoUrl,
                CreatedAt = t.CreatedAt
            });
        }

        public async Task<TechnologyGetDto?> GetByIdAsync(int id)
        {
            var t = await _repo.GetByIdAsync(id);
            if (t == null) return null;

            return new TechnologyGetDto
            {
                TechnologyId = t.TechnologyId,
                TrackId = t.TrackId,
                TechnologyName = t.TechnologyName,
                Description = t.Description,
                VideoUrl = t.VideoUrl,
                CreatedAt = t.CreatedAt
            };
        }

        public async Task<TechnologyGetDto> AddAsync(TechnologyPostDto dto)
        {
            var entity = new Technology
            {
                TrackId = dto.TrackId,
                TechnologyName = dto.TechnologyName,
                Description = dto.Description,
                VideoUrl = dto.VideoUrl
            };

            var added = await _repo.AddAsync(entity);

            return new TechnologyGetDto
            {
                TechnologyId = added.TechnologyId,
                TrackId = added.TrackId,
                TechnologyName = added.TechnologyName,
                Description = added.Description,
                VideoUrl = added.VideoUrl,
                CreatedAt = added.CreatedAt
            };
        }

        public async Task<TechnologyGetDto?> UpdateAsync(int id, TechnologyPostDto dto)
        {
            var entity = new Technology
            {
                TechnologyId = id,
                TrackId = dto.TrackId,
                TechnologyName = dto.TechnologyName,
                Description = dto.Description,
                VideoUrl = dto.VideoUrl
            };

            var updated = await _repo.UpdateAsync(entity);
            if (updated == null) return null;

            return new TechnologyGetDto
            {
                TechnologyId = updated.TechnologyId,
                TrackId = updated.TrackId,
                TechnologyName = updated.TechnologyName,
                Description = updated.Description,
                VideoUrl = updated.VideoUrl,
                CreatedAt = updated.CreatedAt
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
