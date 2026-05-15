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
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                var adminRole = new IdentityRole("Admin");
                await _roleManager.CreateAsync(adminRole);
            }

            var adminEmail = "esraaTaha3092001@gmail.com";

            var admin = await _userManager.FindByEmailAsync(adminEmail);
            if (admin is null)
            {
                admin = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FullName = "Esraa Taha",
                    EmailConfirmed = true
                };

                var res = await _userManager.CreateAsync(admin, "HOHO123!");

                if (!res.Succeeded)
                {
                    throw new Exception($"Failed to create admin user: {string.Join(", ", res.Errors.Select(e => e.Description))}");
                }
            }

            if (!await _userManager.IsInRoleAsync(admin, "Admin"))
            {
                await _userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
