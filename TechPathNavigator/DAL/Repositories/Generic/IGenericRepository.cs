using System.Linq.Expressions;

namespace TechPathNavigator.DAL.Repositories.Generic
{
    /// <summary>
    /// Generic repository interface for common CRUD operations
    /// Reduces code duplication across repositories
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public interface IGenericRepository<T> where T : class
    {
        // Read operations
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        // Write operations
        Task<T> AddAsync(T entity);
        Task<T?> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);

        // Utility operations
        Task<bool> ExistsAsync(int id);
        Task<int> CountAsync();
    }
}
