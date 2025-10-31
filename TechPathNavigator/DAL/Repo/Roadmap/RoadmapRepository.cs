using Microsoft.EntityFrameworkCore;
using TechPathNavigator.Data;
using TechPathNavigator.Models;

namespace TechPathNavigator.Repositories
{
    public class RoadmapRepository : IRoadmapRepository
    {
        private readonly ApplicationDbContext _context;

        public RoadmapRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Roadmap>> GetAllAsync()
        {
            return await _context.Roadmaps
                .Include(r => r.RoadmapSteps.OrderBy(s => s.StepOrder))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Roadmap?> GetByIdAsync(int id)
        {
            return await _context.Roadmaps
                .Include(r => r.RoadmapSteps.OrderBy(s => s.StepOrder))
                .FirstOrDefaultAsync(r => r.RoadmapId == id);
        }

        public async Task<Roadmap> AddAsync(Roadmap roadmap)
        {
            _context.Roadmaps.Add(roadmap);
            await _context.SaveChangesAsync();
            return roadmap;
        }

        public async Task<Roadmap?> UpdateAsync(Roadmap roadmap)
        {
            var existing = await _context.Roadmaps.FindAsync(roadmap.RoadmapId);
            if (existing == null) return null;

            existing.Title = roadmap.Title;
            existing.Description = roadmap.Description;
            existing.TrackId = roadmap.TrackId;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var roadmap = await _context.Roadmaps.FindAsync(id);
            if (roadmap == null) return false;

            _context.Roadmaps.Remove(roadmap);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}