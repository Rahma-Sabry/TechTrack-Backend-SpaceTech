using Microsoft.EntityFrameworkCore;
using TechPathNavigator.Data;
using TechPathNavigator.Models;

namespace TechPathNavigator.Repositories
{
    public class RoadmapStepRepository : IGenericRepository<RoadmapStep>, IRoadmapStepRepository
    {
        private readonly ApplicationDbContext _context;

        public RoadmapStepRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<RoadmapStep>> GetAllAsync()
        {
            return await _context.RoadmapSteps
                .ToListAsync();
        }

        public async Task<IEnumerable<RoadmapStep>> GetAllByRoadmapIdAsync(int roadmapId)
        {
            return await _context.RoadmapSteps
                .Where(s => s.RoadmapId == roadmapId)
                .OrderBy(s => s.StepOrder)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<RoadmapStep?> GetByIdAsync(int id)
        {
            return await _context.RoadmapSteps
                .FirstOrDefaultAsync(s => s.RoadmapStepId == id);
        }

        public async Task<RoadmapStep> AddAsync(RoadmapStep step)
        {
            _context.RoadmapSteps.Add(step);
            await _context.SaveChangesAsync();
            return step;
        }

        public async Task<RoadmapStep?> UpdateAsync(RoadmapStep step)
        {
            var existing = await _context.RoadmapSteps.FindAsync(step.RoadmapStepId);
            if (existing == null) return null;

            existing.StepTitle = step.StepTitle;
            existing.StepDescription = step.StepDescription;
            existing.StepOrder = step.StepOrder;
            existing.RoadmapId = step.RoadmapId;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var step = await _context.RoadmapSteps.FindAsync(id);
            if (step == null) return false;

            _context.RoadmapSteps.Remove(step);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
