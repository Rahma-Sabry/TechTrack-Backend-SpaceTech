using Microsoft.EntityFrameworkCore;
using TechPathNavigator.Data;
using TechPathNavigator.Models;

namespace TechPathNavigator.Repositories
{
    public class TechnologyRepository : IGenericRepository<Technology>, ITechnologyRepository
    {
        private readonly ApplicationDbContext _context;

        public TechnologyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Technology>> GetAllAsync()
        {
            return await _context.Technologies
                .Include(t => t.Track)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Technology?> GetByIdAsync(int id)
        {
            return await _context.Technologies
                .Include(t => t.Track)
                .FirstOrDefaultAsync(t => t.TechnologyId == id);
        }

        public async Task<IEnumerable<Technology>> GetBySubCategoryIdAsync(int subCategoryId)
        {
            return await _context.Technologies
                .Include(t => t.Track)
                .Where(t => t.Track.SubCategoryId == subCategoryId)
                .AsNoTracking()
                .ToListAsync();
        }

        // ← Add this method to satisfy the interface
        public async Task<IEnumerable<Technology>> GetByTrackIdAsync(int trackId)
        {
            return await _context.Technologies
                .Include(t => t.Track)
                .Where(t => t.TrackId == trackId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Technology> AddAsync(Technology technology)
        {
            _context.Technologies.Add(technology);
            await _context.SaveChangesAsync();
            return technology;
        }

        public async Task<Technology?> UpdateAsync(Technology technology)
        {
            var existing = await _context.Technologies.FindAsync(technology.TechnologyId);
            if (existing == null) return null;

            existing.TrackId = technology.TrackId;
            existing.TechnologyName = technology.TechnologyName;
            existing.Description = technology.Description;
            existing.VideoUrl = technology.VideoUrl;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tech = await _context.Technologies.FindAsync(id);
            if (tech == null) return false;

            _context.Technologies.Remove(tech);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
