using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ToDoListApp.BLL.Interfaces;
using ToDoListApp.BLL.Services;
using ToDoListApp.DAL;
using ToDoListApp.DAL.Interfaces;
using ToDoListApp.DAL.Repositories;

namespace ToDoListApp.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            
            builder.Services.AddDbContext<ToDoListAppDbContext>(options =>
                options.UseSqlServer(ConnectionString)
                       .LogTo(message => Debug.WriteLine(message), Microsoft.Extensions.Logging.LogLevel.Information)
                       .EnableSensitiveDataLogging()
                     //.UseLazyLoadingProxies()
            );

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IToDoItemRepo, ToDoItemRepo>();
            builder.Services.AddScoped<IToDoItemService, ToDoItemService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
