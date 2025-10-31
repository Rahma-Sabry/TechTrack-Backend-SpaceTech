using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TechPathNavigator.DAL.Data;

namespace TechPathNavigator.DAL.Repositories.Generic
{
    /// <summary>
    /// Generic repository implementation with Entity Framework Core
    /// Provides reusable CRUD operations for all entities
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        /// <summary>
        /// Retrieves all entities from the database with no tracking
        /// </summary>
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Retrieves a single entity by its primary key
        /// </summary>
        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        /// <summary>
        /// Finds entities matching the specified predicate
        /// </summary>
        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Adds a new entity to the database
        /// </summary>
        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Updates an existing entity
        /// Returns null if entity not found
        /// </summary>
        public virtual async Task<T?> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Deletes an entity by its primary key
        /// </summary>
        public virtual async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return false;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Checks if an entity exists by its primary key
        /// </summary>
        public virtual async Task<bool> ExistsAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            return entity != null;
        }

        /// <summary>
        /// Returns the total count of entities
        /// </summary>
        public virtual async Task<int> CountAsync()
        {
            return await _dbSet.CountAsync();
        }
    }
}
