using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using ToDoListApp.DAL.DataSeeding.Implementation;
using ToDoListApp.BLL.Services.Abstraction;
using ToDoListApp.BLL.Services.Implementation;
using ToDoListApp.DAL.DataSeeding.Abstraction;

namespace ToDoListApp.BLL.Common
{
    public static class ModularBusinessLogicLayer
    {
        public static IServiceCollection AddBusinessInBLL(this IServiceCollection services)
        {
            services.AddScoped<IDataInitializer, DataInitializer>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IToDoItemService, ToDoItemService>();

            return services;
        }
    }
}
