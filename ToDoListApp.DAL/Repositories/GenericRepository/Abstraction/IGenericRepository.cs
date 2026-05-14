using System.Linq.Expressions;

namespace ToDoListApp.DAL.Repositories.GenericRepository.Abstraction
{
    public interface IGenericRepository<TEntity>
    {
        public IQueryable<TEntity> GetAllEntities();

        public IQueryable<TEntity> GetEntityById(int id);

        public Task AddEntityAsync(TEntity entity);

        public void UpdateEntity(TEntity entity);

        public Task DeleteEntityAsync(int id);

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
