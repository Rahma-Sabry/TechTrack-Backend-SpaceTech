using System.Collections.Generic;
using System.Threading.Tasks;
using TechPathNavigator.DTOs;

namespace TechPathNavigator.Services
{
    public interface ISubCategoryService
    {
        Task<IEnumerable<SubCategoryGetDto>> GetAllAsync();

        Task<SubCategoryGetDto?> GetByIdAsync(int id);

        Task<SubCategoryGetDto> AddAsync(SubCategoryPostDto subCategoryDto);

        Task<SubCategoryGetDto?> UpdateAsync(int id, SubCategoryPostDto subCategoryDto);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<SubCategoryGetDto>> GetByCategoryIdAsync(int categoryId);
    }
}