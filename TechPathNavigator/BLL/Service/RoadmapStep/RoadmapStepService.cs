using TechPathNavigator.DTOs;
using TechPathNavigator.Models;
using TechPathNavigator.Repositories;
using TechPathNavigator.Extensions;
using TechPathNavigator.Common.Errors;
using TechPathNavigator.Common.Messages;
using TechPathNavigator.Common.Results;

namespace TechPathNavigator.Services
{
    public class RoadmapStepService : IRoadmapStepService
    {
        private readonly IRoadmapStepRepository _repo;

        public RoadmapStepService(IRoadmapStepRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        // Get all steps for a roadmap
        public async Task<IEnumerable<RoadmapStepGetDto>> GetAllByRoadmapIdAsync(int roadmapId)
        {
            var steps = await _repo.GetAllByRoadmapIdAsync(roadmapId);
            return steps.Select(s => s.ToGetDto());
        }

        // Get a step by its ID
        public async Task<RoadmapStepGetDto> GetByIdAsync(int id)
        {
            var step = await _repo.GetByIdAsync(id);
            if (step == null)
                throw new Exception(ErrorMessages.RoadmapStep_NotFound); // Use proper error messages

            return step.ToGetDto();
        }

        // Add a new step
        public async Task<RoadmapStepGetDto> AddAsync(RoadmapStepPostDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            // Optional: validate required fields
            if (string.IsNullOrWhiteSpace(dto.StepTitle))
                throw new Exception(ErrorMessages.RoadmapStep_TitleRequired);

            var entity = dto.ToEntity();
            var added = await _repo.AddAsync(entity);
            return added.ToGetDto();
        }

        // Update an existing step
        public async Task<RoadmapStepGetDto> UpdateAsync(int id, RoadmapStepPostDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                throw new Exception(ErrorMessages.RoadmapStep_NotFound);

            // Update only properties that exist
            existing.StepTitle = dto.StepTitle ?? existing.StepTitle;
            existing.StepDescription = dto.StepDescription ?? existing.StepDescription;
            existing.StepOrder = dto.StepOrder;

            var updated = await _repo.UpdateAsync(existing);
            return updated.ToGetDto();
        }

        // Delete a step
        public async Task<bool> DeleteAsync(int id)
        {
            var deleted = await _repo.DeleteAsync(id);
            if (!deleted) throw new Exception(ErrorMessages.RoadmapStep_NotFound);
            return true;
        }
    }
}
