using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechPathNavigator.Common.Errors;
using TechPathNavigator.DTOs;
using TechPathNavigator.Extensions;
using TechPathNavigator.Models;
using TechPathNavigator.Repositories;
using TechPathNavigator.Service.Technology;

namespace TechPathNavigator.Services
{
    public class TechnologyService : ITechnologyService
    {
        private readonly ITechnologyRepository _repo;

        public TechnologyService(ITechnologyRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<IEnumerable<TechnologyGetDto>> GetAllAsync()
        {
            var techs = await _repo.GetAllAsync();
            return techs.Select(t => t.ToGetDto());
        }

        public async Task<TechnologyGetDto?> GetByIdAsync(int id)
        {
            var tech = await _repo.GetByIdAsync(id);
            return tech?.ToGetDto();
        }

        public async Task<IEnumerable<TechnologyGetDto>> GetByTrackIdAsync(int trackId)
        {
            var techs = await _repo.GetByTrackIdAsync(trackId);
            return techs.Select(t => t.ToGetDto());
        }

        public async Task<TechnologyGetDto> AddAsync(TechnologyPostDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.TechnologyName))
                throw new ArgumentException(ErrorMessages.Technology_NameRequired);

            var entity = dto.ToEntity();
            var added = await _repo.AddAsync(entity);
            return added.ToGetDto();
        }

        public async Task<TechnologyGetDto?> UpdateAsync(int id, TechnologyPostDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return null;

            existing.TrackId = dto.TrackId;
            existing.TechnologyName = dto.TechnologyName ?? existing.TechnologyName;
            existing.Description = dto.Description ?? existing.Description;
            existing.VideoUrl = dto.VideoUrl ?? existing.VideoUrl;

            var updated = await _repo.UpdateAsync(existing);
            return updated?.ToGetDto();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
