using TechPathNavigator.Models;

namespace TechPathNavigator.Repositories
{
    public interface ICompanyTechnologyRepository : IGenericRepository<CompanyTechnology>
    {
      /*  Task<IEnumerable<CompanyTechnology>> GetAllAsync();
        Task<CompanyTechnology?> GetByIdAsync(int id);
        Task<CompanyTechnology> AddAsync(CompanyTechnology entity);
        Task<CompanyTechnology?> UpdateAsync(CompanyTechnology entity);
        Task<bool> DeleteAsync(int id);*/
        Task<bool> CompanyExistsAsync(int companyId);
        Task<bool> TechnologyExistsAsync(int technologyId);
        Task<bool> PairExistsAsync(int companyId, int technologyId);
    }
}


