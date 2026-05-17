using System.Linq.Expressions;
using ToDoListApp.DAL.Repositories.GenericRepository.Abstraction;
using ToDoListApp.DAL.Database;

namespace ToDoListApp.DAL.Repositories.GenericRepository.Implementation
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity<int>
    {
        private readonly ToDoListAppDbContext _dbContext;

        public GenericRepository(ToDoListAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TEntity>> GetAllEntitiesAsync(Expression<Func<TEntity, bool>>? predicate = null, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                IQueryable<TEntity> query = _dbContext.Set<TEntity>();

                if (predicate is not null)
                {
                    query = query.Where(predicate);
                }

                foreach (var include in includes)
                {
                    query = query.Include(include);
                }

                return await query.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TEntity?> GetEntityByIdAsync(int id, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                IQueryable<TEntity> query = _dbContext.Set<TEntity>();

                foreach (var include in includes)
                {
                    query = query.Include(include);
                }

                return await query.FirstOrDefaultAsync(e => e.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddEntityAsync(TEntity entity)
        {
            try
            {
                await _dbContext.Set<TEntity>().AddAsync(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateEntity(TEntity entity)
        {
            try
            {
                _dbContext.Set<TEntity>().Update(entity);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteEntityAsync(int id)
        {
            try
            {
                var entity = await _dbContext.Set<TEntity>().FindAsync(id);
                _dbContext.Set<TEntity>().Remove(entity!);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await _dbContext.Set<TEntity>().AnyAsync(predicate);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null)
        {
            try
            {
                if (predicate is not null)
                {
                    return await _dbContext.Set<TEntity>().CountAsync(predicate);
                }
                else
                {
                    return await _dbContext.Set<TEntity>().CountAsync();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
