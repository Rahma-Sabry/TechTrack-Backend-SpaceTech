using TechPathNavigator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechPathNavigator.Repositories
{
    public interface ITechnologyRepository : IGenericRepository<Technology>
    {
        Task<IEnumerable<Technology>> GetByTrackIdAsync(int trackId); // added
      /*  Task<IEnumerable<Technology>> GetAllAsync();
        Task<Technology?> GetByIdAsync(int id);
       
        Task<Technology> AddAsync(Technology entity);
        Task<Technology?> UpdateAsync(Technology entity);
        Task<bool> DeleteAsync(int id); */
    }
}
