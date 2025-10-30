using Microsoft.EntityFrameworkCore;
using TechPathNavigator.Data;
using TechPathNavigator.DTOs;
using TechPathNavigator.Mappers;
using TechPathNavigator.Models;
using TechPathNavigator.Common;
using TechPathNavigator.Service.Track;

namespace TechPathNavigator.Services
{
    public class TrackService : ITrackService
    {
        private readonly ApplicationDbContext _context;

        public TrackService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TrackGetDto>> GetAllTracksAsync()
        {
            var tracks = await _context.Tracks.ToListAsync();
            return tracks.Select(t => t.ToDto<Track, TrackGetDto>());
        }

        public async Task<TrackGetDto?> GetTrackByIdAsync(int id)
        {
            var track = await _context.Tracks.FindAsync(id);
            return track?.ToDto<Track, TrackGetDto>();
        }

        public async Task<TrackGetDto> CreateTrackAsync(TrackPostDto trackDto)
        {
            ValidateTrackDto(trackDto);

            var track = trackDto.ToEntity<Track, TrackPostDto>();
            _context.Tracks.Add(track);
            await _context.SaveChangesAsync();
            return track.ToDto<Track, TrackGetDto>();
        }

        public async Task<TrackGetDto?> UpdateTrackAsync(int id, TrackPostDto trackDto)
        {
            var existingTrack = await _context.Tracks.FindAsync(id);
            if (existingTrack == null) return null;

            ValidateTrackDto(trackDto);

            var updatedTrack = trackDto.ToEntity<Track, TrackPostDto>(id);
            _context.Entry(existingTrack).CurrentValues.SetValues(updatedTrack);
            await _context.SaveChangesAsync();

            return updatedTrack.ToDto<Track, TrackGetDto>();
        }

        public async Task<bool> DeleteTrackAsync(int id)
        {
            var track = await _context.Tracks.FindAsync(id);
            if (track == null) return false;

            _context.Tracks.Remove(track);
            await _context.SaveChangesAsync();
            return true;
        }

        // -------------------
        // Validation logic using AppConstants
        // -------------------
        private void ValidateTrackDto(TrackPostDto trackDto)
        {
            if (trackDto.SubCategoryId <= 0)
                throw new ArgumentException(AppConstants.TrackSubCategoryIdRequired);

            if (string.IsNullOrWhiteSpace(trackDto.TrackName))
                throw new ArgumentException(AppConstants.TrackNameRequired);

            if (trackDto.EstimatedDuration <= 0)
                throw new ArgumentException(AppConstants.TrackEstimatedDurationRequired);

            if (!string.IsNullOrEmpty(trackDto.DifficultyLevel) &&
                !AppConstants.TrackDifficultyLevels.Contains(trackDto.DifficultyLevel))
            {
                throw new ArgumentException(
                    AppConstants.TrackDifficultyLevelInvalid + string.Join(", ", AppConstants.TrackDifficultyLevels)
                );
            }
        }
    }
}
