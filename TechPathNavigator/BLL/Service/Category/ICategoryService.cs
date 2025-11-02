using System.Collections.Generic;
using System.Threading.Tasks;
using TechPathNavigator.DTOs;
using TechPathNavigator.Models;


namespace TechPathNavigator.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryGetDto>> GetAllCategoriesAsync();
        Task<CategoryGetDto?> GetCategoryByIdAsync(int id);
        Task<CategoryGetDto> CreateCategoryAsync(CategoryPostDto dto);
        Task<CategoryGetDto?> UpdateCategoryAsync(int id, CategoryPostDto dto);
        Task<bool> DeleteCategoryAsync(int id);
    }
}