using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechPathNavigator.Common.Errors;
using TechPathNavigator.DTOs;
using TechPathNavigator.Extensions;
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
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<IEnumerable<TrackGetDto>> GetAllAsync()
        {
            var tracks = await _repo.GetAllAsync();
            return tracks.Select(t => t.ToGetDto());
        }

        public async Task<TrackGetDto?> GetByIdAsync(int id)
        {
            var track = await _repo.GetByIdAsync(id);
            return track?.ToGetDto();
        }

        public async Task<TrackGetDto> AddAsync(TrackPostDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.TrackName))
                throw new ArgumentException(ErrorMessages.Track_NameRequired);

            var entity = dto.ToEntity();
            var added = await _repo.AddAsync(entity);
            return added.ToGetDto();
        }

        public async Task<TrackGetDto?> UpdateAsync(int id, TrackPostDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return null;

            existing.TrackName = dto.TrackName ?? existing.TrackName;
            existing.Description = dto.Description ?? existing.Description;

            var updated = await _repo.UpdateAsync(existing);
            return updated?.ToGetDto();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
