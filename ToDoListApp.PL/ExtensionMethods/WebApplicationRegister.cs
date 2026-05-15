using ToDoListApp.DAL.DataSeeding.Abstraction;
using ToDoListApp.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ToDoListApp.PL.ExtensionMethods
{
    public static class WebApplicationRegister
    {
        public static async Task<WebApplication> SeedDataAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dataIntializer = scope.ServiceProvider.GetRequiredService<IDataInitializer>();
            await dataIntializer.InitializeIdentityDataAsync();

            return app;
        }

        public static async Task<WebApplication> ApplyPendingMigrationsAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ToDoListAppDbContext>();
            var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();

            if (pendingMigrations.Any())
            {
                await dbContext.Database.MigrateAsync();
            }
            return app;
        }
    }
}
