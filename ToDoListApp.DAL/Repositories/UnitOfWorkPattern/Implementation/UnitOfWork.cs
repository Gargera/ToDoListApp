using ToDoListApp.DAL.Database;
using ToDoListApp.DAL.Repositories.GenericRepository.Abstraction;
using ToDoListApp.DAL.Repositories.GenericRepository.Implementation;
using ToDoListApp.DAL.Repositories.UnitOfWorkPattern.Abstraction;

namespace ToDoListApp.DAL.Repositories.UnitOfWorkPattern.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ToDoListAppDbContext _dbContext;
        public IGenericRepository<ToDoItem> ToDoItems { get; }
        public IGenericRepository<Category> Categories { get; }

        public UnitOfWork(ToDoListAppDbContext dbContext)
        {
            _dbContext = dbContext;
            ToDoItems = new GenericRepository<ToDoItem>(dbContext);
            Categories = new GenericRepository<Category>(dbContext);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
