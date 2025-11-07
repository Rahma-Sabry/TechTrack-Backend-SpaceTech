using TechPathNavigator.Models;

namespace TechPathNavigator.Repositories
{
    public interface IRoadmapStepRepository: IGenericRepository<RoadmapStep>
    {
        Task<IEnumerable<RoadmapStep>> GetAllByRoadmapIdAsync(int roadmapId);
     /*   Task<RoadmapStep?> GetByIdAsync(int id);
        Task<RoadmapStep> AddAsync(RoadmapStep step);
        Task<RoadmapStep?> UpdateAsync(RoadmapStep step);
        Task<bool> DeleteAsync(int id);
     */
    }
}
