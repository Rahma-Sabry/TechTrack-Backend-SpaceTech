using System.Threading.Tasks;
using TechPathNavigator.DTOs;

namespace TechPathNavigator.Services
{
    public interface IRoadmapStepService
    {
        Task<IEnumerable<RoadmapStepGetDto>> GetAllByRoadmapIdAsync(int roadmapId);
        Task<RoadmapStepGetDto?> GetByIdAsync(int id);
        Task<RoadmapStepGetDto> AddAsync(RoadmapStepPostDto dto);
        Task<RoadmapStepGetDto> UpdateAsync(int id, RoadmapStepPostDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
