using TechPathNavigator.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechPathNavigator.Service.Technology
{
    public interface ITechnologyService
    {
        Task<IEnumerable<TechnologyGetDto>> GetAllAsync();
        Task<TechnologyGetDto?> GetByIdAsync(int id);
        Task<IEnumerable<TechnologyGetDto>> GetByTrackIdAsync(int trackId); // fixed
        Task<TechnologyGetDto> AddAsync(TechnologyPostDto dto);
        Task<TechnologyGetDto?> UpdateAsync(int id, TechnologyPostDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
