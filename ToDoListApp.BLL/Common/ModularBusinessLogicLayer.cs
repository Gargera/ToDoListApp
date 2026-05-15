using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoListApp.BLL.Services.Abstraction;
using ToDoListApp.BLL.Services.Implementation;

namespace ToDoListApp.BLL.Common
{
    public static class ModularBusinessLogicLayer
    {
        public static IServiceCollection AddBusinessInBLL(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IToDoItemService, ToDoItemService>();

            return services;
        }
    }
}
