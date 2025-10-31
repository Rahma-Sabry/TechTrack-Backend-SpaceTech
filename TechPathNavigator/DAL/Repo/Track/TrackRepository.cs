using Microsoft.EntityFrameworkCore;
using TechPathNavigator.DAL.Data;
using TechPathNavigator.Models;

namespace TechPathNavigator.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly ApplicationDbContext _context;

        public TrackRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Track>> GetAllAsync()
        {
            return await _context.Tracks
                .Include(t => t.SubCategory)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Track?> GetByIdAsync(int id)
        {
            return await _context.Tracks
                .Include(t => t.SubCategory)
                .FirstOrDefaultAsync(t => t.TrackId == id);
        }

        public async Task<Track> AddAsync(Track track)
        {
            _context.Tracks.Add(track);
            await _context.SaveChangesAsync();
            return track;
        }

        public async Task<Track?> UpdateAsync(Track track)
        {
            var existing = await _context.Tracks.FindAsync(track.TrackId);
            if (existing == null) return null;

            existing.TrackName = track.TrackName;
            existing.Description = track.Description;
            existing.DifficultyLevel = track.DifficultyLevel;
            existing.EstimatedDuration = track.EstimatedDuration;
            existing.SubCategoryId = track.SubCategoryId;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var track = await _context.Tracks.FindAsync(id);
            if (track == null) return false;

            _context.Tracks.Remove(track);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
