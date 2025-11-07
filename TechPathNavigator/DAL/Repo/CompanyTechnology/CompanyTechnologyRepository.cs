using Microsoft.EntityFrameworkCore;
using TechPathNavigator.Data;
using TechPathNavigator.Models;

namespace TechPathNavigator.Repositories
{
    public class CompanyTechnologyRepository : IGenericRepository<CompanyTechnology>, ICompanyTechnologyRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyTechnologyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CompanyTechnology>> GetAllAsync()
        {
            return await _context.CompanyTechnologies
                .Include(ct => ct.Company)
                .Include(ct => ct.Technology)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<CompanyTechnology?> GetByIdAsync(int id)
        {
            return await _context.CompanyTechnologies
                .Include(ct => ct.Company)
                .Include(ct => ct.Technology)
                .FirstOrDefaultAsync(ct => ct.CompanyTechnologyId == id);
        }

        public async Task<CompanyTechnology> AddAsync(CompanyTechnology entity)
        {
            _context.CompanyTechnologies.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<CompanyTechnology?> UpdateAsync(CompanyTechnology entity)
        {
            var existing = await _context.CompanyTechnologies.FindAsync(entity.CompanyTechnologyId);
            if (existing == null) return null;

            existing.CompanyId = entity.CompanyId;
            existing.TechnologyId = entity.TechnologyId;
            existing.UsageLevel = entity.UsageLevel;
            existing.Notes = entity.Notes;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.CompanyTechnologies.FindAsync(id);
            if (existing == null) return false;
            _context.CompanyTechnologies.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CompanyExistsAsync(int companyId)
        {
            return await _context.Companies.AnyAsync(c => c.CompanyId == companyId);
        }

        public async Task<bool> TechnologyExistsAsync(int technologyId)
        {
            return await _context.Technologies.AnyAsync(t => t.TechnologyId == technologyId);
        }

        public async Task<bool> PairExistsAsync(int companyId, int technologyId)
        {
            return await _context.CompanyTechnologies.AnyAsync(ct => ct.CompanyId == companyId && ct.TechnologyId == technologyId);
        }
    }
}


