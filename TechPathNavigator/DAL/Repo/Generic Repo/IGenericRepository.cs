using System.Linq.Expressions;

namespace TechPathNavigator.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T?> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        //Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        //Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    }
}

