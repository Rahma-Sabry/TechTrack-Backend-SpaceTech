using TechPathNavigator.DTOs;
using TechPathNavigator.Models;
using TechPathNavigator.Repositories;

namespace TechPathNavigator.Service.Track
{
    public interface ITrackService
    {
        Task<IEnumerable<TrackGetDto>> GetAllAsync();
        Task<TrackGetDto?> GetByIdAsync(int id);
        Task<TrackGetDto> AddAsync(TrackPostDto dto);
        Task<TrackGetDto?> UpdateAsync(int id, TrackPostDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
