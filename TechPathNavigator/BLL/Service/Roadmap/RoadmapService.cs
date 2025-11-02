using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechPathNavigator.DTOs;
using TechPathNavigator.Models;
using TechPathNavigator.Repositories;
using TechPathNavigator.Extensions;
using TechPathNavigator.Common.Messages;
using TechPathNavigator.Common.Errors;

namespace TechPathNavigator.Services
{
    public class RoadmapService : IRoadmapService
    {
        private readonly IRoadmapRepository _repo;

        public RoadmapService(IRoadmapRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<IEnumerable<RoadmapGetDto>> GetAllAsync()
        {
            var roadmaps = await _repo.GetAllAsync();
            // Handle possible null collection from repo
            return roadmaps?.Select(r => r.ToGetDto()) ?? new List<RoadmapGetDto>();
        }

        public async Task<RoadmapGetDto?> GetByIdAsync(int id)
        {
            var roadmap = await _repo.GetByIdAsync(id);
            if (roadmap == null) return null; // return null if not found
            return roadmap.ToGetDto();
        }

        public async Task<RoadmapGetDto> AddAsync(RoadmapPostDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var entity = dto.ToEntity(); // use mapping extension
            var added = await _repo.AddAsync(entity);

            if (added == null)
                throw new InvalidOperationException(ErrorMessages.Roadmap_NotCreated); // use your API message

            return added.ToGetDto();
        }

        public async Task<RoadmapGetDto> UpdateAsync(int id, RoadmapPostDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                throw new InvalidOperationException(ApiMessages.RoadmapNotFound); // use API message

            var entity = dto.ToEntity(id); // mapping extension with id
            var updated = await _repo.UpdateAsync(entity);

            if (updated == null)
                throw new InvalidOperationException(ErrorMessages.Roadmap_NotUpdated);

            return updated.ToGetDto();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleted = await _repo.DeleteAsync(id);
            if (!deleted) throw new InvalidOperationException(ApiMessages.RoadmapNotFound);
            return true;
        }
    }
}
