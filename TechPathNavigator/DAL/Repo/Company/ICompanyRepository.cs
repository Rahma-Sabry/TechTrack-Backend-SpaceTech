using TechPathNavigator.Models;

namespace TechPathNavigator.Repositories
{
    public interface ICompanyRepository : IGenericRepository<Company>
    {
       /* Task<IEnumerable<Company>> GetAllAsync();
        Task<Company?> GetByIdAsync(int id);
        Task<Company> AddAsync(Company company);
        Task<Company?> UpdateAsync(Company company);
        Task<bool> DeleteAsync(int id);
       */
        Task<bool> CompanyNameExistsAsync(string companyName);
    }
}


