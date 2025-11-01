using TechPathNavigator.Models;

namespace TechPathNavigator.Repositories
{
    public interface ITrackRepository
    {
        Task<IEnumerable<Track>> GetAllAsync();
        Task<Track?> GetByIdAsync(int id);
        Task<Track> AddAsync(Track track);
        Task<Track?> UpdateAsync(Track track);
        Task<bool> DeleteAsync(int id);
    }
}
