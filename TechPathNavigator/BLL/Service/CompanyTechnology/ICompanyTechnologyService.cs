using TechPathNavigator.Common.Results;
using TechPathNavigator.DTOs;

namespace TechPathNavigator.Services
{
    public interface ICompanyTechnologyService
    {
        Task<IEnumerable<CompanyTechnologyGetDto>> GetAllAsync();
        Task<CompanyTechnologyGetDto?> GetByIdAsync(int id);
        Task<ServiceResult<CompanyTechnologyGetDto>> CreateAsync(CompanyTechnologyPostDto dto);
        Task<ServiceResult<CompanyTechnologyGetDto>> UpdateAsync(int id, CompanyTechnologyPostDto dto);
        Task<bool> DeleteAsync(int id);
    }
}


