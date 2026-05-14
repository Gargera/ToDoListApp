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

        public IQueryable<TEntity> GetAllEntities()
        {
            return _dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> GetEntityById(int id)
        {
            return _dbContext.Set<TEntity>().Where(e => e.Id == id);
        }

        public async Task AddEntityAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public void UpdateEntity(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }

        public async Task DeleteEntityAsync(int id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            _dbContext.Set<TEntity>().Remove(entity!);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().AnyAsync(predicate);
        }
    }
}
