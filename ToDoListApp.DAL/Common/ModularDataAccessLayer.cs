using Microsoft.Extensions.DependencyInjection;
using ToDoListApp.DAL.Repositories.UnitOfWorkPattern.Implementation;
using ToDoListApp.DAL.Repositories.UnitOfWorkPattern.Abstraction;

namespace ToDoListApp.DAL.Common
{
    public static class ModularDataAccessLayer
    {
        public static IServiceCollection AddBusinessInDAL(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
