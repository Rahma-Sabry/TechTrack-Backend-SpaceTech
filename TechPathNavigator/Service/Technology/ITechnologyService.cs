using TechPathNavigator.DTOs;

namespace TechPathNavigator.Service.Technology
{
    public interface ITechnologyService
    {
        Task<IEnumerable<TechnologyGetDto>> GetAllAsync();
        Task<TechnologyGetDto?> GetByIdAsync(int id);
        Task<TechnologyGetDto> AddAsync(TechnologyPostDto dto);
        Task<TechnologyGetDto?> UpdateAsync(int id, TechnologyPostDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
