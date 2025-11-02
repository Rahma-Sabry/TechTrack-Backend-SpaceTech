using System.Threading.Tasks;
using TechPathNavigator.DTOs;

namespace TechPathNavigator.Services
{
    public interface IRoadmapService
    {
        Task<IEnumerable<RoadmapGetDto>> GetAllAsync();
        Task<RoadmapGetDto?> GetByIdAsync(int id);
        Task<RoadmapGetDto> AddAsync(RoadmapPostDto dto);

        Task<RoadmapGetDto> UpdateAsync(int id, RoadmapPostDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
