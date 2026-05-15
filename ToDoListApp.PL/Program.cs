using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ToDoListApp.DAL.Common;
using ToDoListApp.BLL.Common;
using ToDoListApp.DAL.Database;
using ToDoListApp.DAL.Entities;
using ToDoListApp.PL.ExtensionMethods;

namespace ToDoListApp.PL
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ToDoListAppDbContext>(options =>
                options.UseSqlServer(ConnectionString)
                       .LogTo(message => Debug.WriteLine(message), Microsoft.Extensions.Logging.LogLevel.Information)
                       .EnableSensitiveDataLogging()
            );
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddBusinessInDAL();
            builder.Services.AddBusinessInBLL ();

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(typeof(BLL.Mapper.DomainProfile));
                cfg.AddProfile(typeof(PL.Mapper.DomainProfile));
            });

            builder.Services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;

                options.User.RequireUniqueEmail = true;

                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            })
                .AddEntityFrameworkStores<ToDoListAppDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/LogIn";
                options.AccessDeniedPath = "/Account/AccessDenied";
            });

            var app = builder.Build();

            await app.ApplyPendingMigrationsAsync();
            await app.SeedDataAsync();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
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
