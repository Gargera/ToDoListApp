using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ToDoListApp.DAL.Database
{
    public class ToDoListAppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }

        public ToDoListAppDbContext(DbContextOptions<ToDoListAppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ToDoListAppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
