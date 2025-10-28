using TechPathNavigator.DTOs;
using TechPathNavigator.Models;
using TechPathNavigator.Repositories;

namespace TechPathNavigator.Services
{
    public class RoadmapStepService
    {
        private readonly IRoadmapStepRepository _repo;

        public RoadmapStepService(IRoadmapStepRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<RoadmapStepGetDto>> GetAllByRoadmapIdAsync(int roadmapId)
        {
            var steps = await _repo.GetAllByRoadmapIdAsync(roadmapId);
            return steps.Select(s => new RoadmapStepGetDto
            {
                RoadmapStepId = s.RoadmapStepId,
                RoadmapId = s.RoadmapId,
                StepTitle = s.StepTitle,
                StepDescription = s.StepDescription,
                StepOrder = s.StepOrder
            });
        }

        public async Task<RoadmapStepGetDto?> GetByIdAsync(int id)
        {
            var step = await _repo.GetByIdAsync(id);
            if (step == null) return null;

            return new RoadmapStepGetDto
            {
                RoadmapStepId = step.RoadmapStepId,
                RoadmapId = step.RoadmapId,
                StepTitle = step.StepTitle,
                StepDescription = step.StepDescription,
                StepOrder = step.StepOrder
            };
        }

        public async Task<RoadmapStepGetDto> AddAsync(RoadmapStepPostDto dto)
        {
            var entity = new RoadmapStep
            {
                RoadmapId = dto.RoadmapId,
                StepTitle = dto.StepTitle,
                StepDescription = dto.StepDescription,
                StepOrder = dto.StepOrder
            };

            var added = await _repo.AddAsync(entity);
            return new RoadmapStepGetDto
            {
                RoadmapStepId = added.RoadmapStepId,
                RoadmapId = added.RoadmapId,
                StepTitle = added.StepTitle,
                StepDescription = added.StepDescription,
                StepOrder = added.StepOrder
            };
        }

        public async Task<RoadmapStepGetDto?> UpdateAsync(int id, RoadmapStepPostDto dto)
        {
            var entity = new RoadmapStep
            {
                RoadmapStepId = id,
                RoadmapId = dto.RoadmapId,
                StepTitle = dto.StepTitle,
                StepDescription = dto.StepDescription,
                StepOrder = dto.StepOrder
            };

            var updated = await _repo.UpdateAsync(entity);
            if (updated == null) return null;

            return new RoadmapStepGetDto
            {
                RoadmapStepId = updated.RoadmapStepId,
                RoadmapId = updated.RoadmapId,
                StepTitle = updated.StepTitle,
                StepDescription = updated.StepDescription,
                StepOrder = updated.StepOrder
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }
    }
}
