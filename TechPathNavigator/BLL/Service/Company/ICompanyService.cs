using TechPathNavigator.Common.Results;
using TechPathNavigator.DTOs;

namespace TechPathNavigator.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyGetDto>> GetAllAsync();
        Task<CompanyGetDto?> GetByIdAsync(int id);
        Task<ServiceResult<CompanyGetDto>> CreateAsync(CompanyPostDto dto);
        Task<ServiceResult<CompanyGetDto>> UpdateAsync(int id, CompanyPostDto dto);
        Task<bool> DeleteAsync(int id);
    }
}


