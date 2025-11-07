using System.Collections.Generic;
using System.Threading.Tasks;
using TechPathNavigator.Models;

namespace TechPathNavigator.Repositories
{
    public interface ISubCategoryRepository: IGenericRepository<SubCategory>
    {
      /*  Task<IEnumerable<SubCategory>> GetAllAsync();
        Task<SubCategory?> GetByIdAsync(int id);
        Task<SubCategory> AddAsync(SubCategory subCategory);
        Task<SubCategory?> UpdateAsync(SubCategory subCategory);
        Task<bool> DeleteAsync(int id); */
        Task<IEnumerable<SubCategory>> GetByCategoryIdAsync(int categoryId);
    }
}