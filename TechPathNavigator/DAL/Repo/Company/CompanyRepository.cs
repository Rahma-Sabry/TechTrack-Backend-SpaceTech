using Microsoft.EntityFrameworkCore;
using TechPathNavigator.Data;
using TechPathNavigator.Models;

namespace TechPathNavigator.Repositories
{
    public class CompanyRepository : IGenericRepository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _context.Companies
                .Include(c => c.CompanyTechnologies)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Company?> GetByIdAsync(int id)
        {
            return await _context.Companies
                .Include(c => c.CompanyTechnologies) 
                .FirstOrDefaultAsync(c => c.CompanyId == id);
        }

        public async Task<Company> AddAsync(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<Company?> UpdateAsync(Company company)
        {
            var existing = await _context.Companies.FindAsync(company.CompanyId);
            if (existing == null) return null;

            existing.CompanyName = company.CompanyName;
            existing.Industry = company.Industry;
            existing.WebsiteUrl = company.WebsiteUrl;
            existing.Description = company.Description;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Companies.FindAsync(id);
            if (entity == null) return false;
            _context.Companies.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CompanyNameExistsAsync(string companyName)
        {
            return await _context.Companies.AnyAsync(c => c.CompanyName == companyName);
        }
    }
}


