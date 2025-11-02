using TechPathNavigator.DTOs;
using TechPathNavigator.Models;

namespace TechPathNavigator.Extensions
{
    public static class RoadmapStepMappingExtensions
    {
        // Map RoadmapStep entity → RoadmapStepGetDto
        public static RoadmapStepGetDto ToGetDto(this RoadmapStep step)
        {
            return new RoadmapStepGetDto
            {
                RoadmapStepId = step.RoadmapStepId,
                RoadmapId = step.RoadmapId,
                StepTitle = step.StepTitle,
                StepDescription = step.StepDescription,
                StepOrder = step.StepOrder
            };
        }

        // Map RoadmapStepPostDto → RoadmapStep entity
        public static RoadmapStep ToEntity(this RoadmapStepPostDto dto, int? id = null)
        {
            return new RoadmapStep
            {
                RoadmapStepId = id ?? 0, // Use id if updating
                RoadmapId = dto.RoadmapId,
                StepTitle = dto.StepTitle,
                StepDescription = dto.StepDescription,
                StepOrder = dto.StepOrder
            };
        }
    }
}
