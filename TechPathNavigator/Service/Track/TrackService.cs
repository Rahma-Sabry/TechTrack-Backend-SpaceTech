using Microsoft.EntityFrameworkCore;
using TechPathNavigator.Data;
using TechPathNavigator.DTOs;
using TechPathNavigator.Mappers;
using TechPathNavigator.Models;

namespace TechPathNavigator.Services
{
    public interface ITrackService
    {
        Task<IEnumerable<TrackDto>> GetAllTracksAsync();
        Task<TrackDto?> GetTrackByIdAsync(int id);
        Task<TrackDto> CreateTrackAsync(TrackDto trackDto);
        Task<TrackDto?> UpdateTrackAsync(int id, TrackDto trackDto);
        Task<bool> DeleteTrackAsync(int id);
    }

    public class TrackService : ITrackService
    {
        private readonly ApplicationDbContext _context;

        public TrackService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all tracks
        public async Task<IEnumerable<TrackDto>> GetAllTracksAsync()
        {
            var tracks = await _context.Tracks
                                       .Include(t => t.Technologies)
                                       .Include(t => t.SubCategory)
                                       .ToListAsync();

            return tracks.Select(t => t.ToDto<Track, TrackDto>());
        }

        // Get track by id
        public async Task<TrackDto?> GetTrackByIdAsync(int id)
        {
            var track = await _context.Tracks
                                      .Include(t => t.Technologies)
                                      .Include(t => t.SubCategory)
                                      .FirstOrDefaultAsync(t => t.TrackId == id);

            return track?.ToDto<Track, TrackDto>();
        }

        // Create new track
        public async Task<TrackDto> CreateTrackAsync(TrackDto trackDto)
        {
            var track = trackDto.ToEntity<Track, TrackDto>();
            _context.Tracks.Add(track);
            await _context.SaveChangesAsync();
            return track.ToDto<Track, TrackDto>();
        }

        // Update existing track
        public async Task<TrackDto?> UpdateTrackAsync(int id, TrackDto trackDto)
        {
            var existingTrack = await _context.Tracks.FindAsync(id);
            if (existingTrack == null) return null;

            var updatedTrack = trackDto.ToEntity<Track, TrackDto>(id);

            _context.Entry(existingTrack).CurrentValues.SetValues(updatedTrack);
            await _context.SaveChangesAsync();

            return updatedTrack.ToDto<Track, TrackDto>();
        }

        // Delete track
        public async Task<bool> DeleteTrackAsync(int id)
        {
            var track = await _context.Tracks.FindAsync(id);
            if (track == null) return false;

            _context.Tracks.Remove(track);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
