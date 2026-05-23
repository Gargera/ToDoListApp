using Microsoft.AspNetCore.Identity;
using ToDoListApp.DAL.DataSeeding.Abstraction;

namespace ToDoListApp.DAL.DataSeeding.Implementation
{
    public class DataInitializer : IDataInitializer
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DataInitializer(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task InitializeIdentityDataAsync()
        {
            if(!await _roleManager.RoleExistsAsync("User"))
            {
                var userRole = new IdentityRole("User");    
                await _roleManager.CreateAsync(userRole);
            }

            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                var adminRole = new IdentityRole("Admin");
                await _roleManager.CreateAsync(adminRole);
            }
        }
    }
}
