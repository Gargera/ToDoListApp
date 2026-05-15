using ToDoListApp.DAL.Repositories.GenericRepository.Abstraction;

namespace ToDoListApp.DAL.Repositories.UnitOfWorkPattern.Abstraction
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenericRepository<ToDoItem> ToDoItems { get; }
        public IGenericRepository<Category> Categories { get; }
        public Task<int> SaveChangesAsync();
    }
}
