using TechPathNavigator.DTOs;
using TechPathNavigator.Models;
using TechPathNavigator.Repositories;

namespace TechPathNavigator.Services
{
    public class RoadmapService
    {
        private readonly IRoadmapRepository _repo;

        public RoadmapService(IRoadmapRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<RoadmapGetDto>> GetAllAsync()
        {
            var roadmaps = await _repo.GetAllAsync();

            return roadmaps.Select(r => new RoadmapGetDto
            {
                RoadmapId = r.RoadmapId,
                TrackId = r.TrackId,
                Title = r.Title,
                Description = r.Description,
                RoadmapSteps = r.RoadmapSteps?.Select(s => new RoadmapStepGetDto
                {
                    RoadmapStepId = s.RoadmapStepId,
                    StepTitle = s.StepTitle,
                    StepDescription = s.StepDescription,
                    StepOrder = s.StepOrder
                }).ToList()
            });
        }

        public async Task<RoadmapGetDto?> GetByIdAsync(int id)
        {
            var r = await _repo.GetByIdAsync(id);
            if (r == null) return null;

            return new RoadmapGetDto
            {
                RoadmapId = r.RoadmapId,
                TrackId = r.TrackId,
                Title = r.Title,
                Description = r.Description,
                RoadmapSteps = r.RoadmapSteps?.Select(s => new RoadmapStepGetDto
                {
                    RoadmapStepId = s.RoadmapStepId,
                    StepTitle = s.StepTitle,
                    StepDescription = s.StepDescription,
                    StepOrder = s.StepOrder
                }).ToList()
            };
        }

        public async Task<RoadmapGetDto> AddAsync(RoadmapPostDto dto)
        {
            var entity = new Roadmap
            {
                Title = dto.Title,
                Description = dto.Description,
                TrackId = dto.TrackId
            };

            var added = await _repo.AddAsync(entity);

            return new RoadmapGetDto
            {
                RoadmapId = added.RoadmapId,
                TrackId = added.TrackId,
                Title = added.Title,
                Description = added.Description
            };
        }

        public async Task<RoadmapGetDto?> UpdateAsync(int id, RoadmapPostDto dto)
        {
            var entity = new Roadmap
            {
                RoadmapId = id,
                TrackId = dto.TrackId,
                Title = dto.Title,
                Description = dto.Description
            };

            var updated = await _repo.UpdateAsync(entity);
            if (updated == null) return null;

            return new RoadmapGetDto
            {
                RoadmapId = updated.RoadmapId,
                TrackId = updated.TrackId,
                Title = updated.Title,
                Description = updated.Description
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
