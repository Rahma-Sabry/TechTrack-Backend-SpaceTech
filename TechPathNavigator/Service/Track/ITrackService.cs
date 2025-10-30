using TechPathNavigator.DTOs;

namespace TechPathNavigator.Service.Track
{
    public interface ITrackService
    {
        Task<IEnumerable<TrackGetDto>> GetAllTracksAsync();
        Task<TrackGetDto?> GetTrackByIdAsync(int id);
        Task<TrackGetDto> CreateTrackAsync(TrackPostDto trackDto);
        Task<TrackGetDto?> UpdateTrackAsync(int id, TrackPostDto trackDto);
        Task<bool> DeleteTrackAsync(int id);
    }
}
