using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.DAL.Entities;
using ToDoListApp.PL.ViewModels.AccountVms;

namespace ToDoListApp.PL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        
        private readonly SignInManager<ApplicationUser> _signInManager;
        
        public AdminController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Users()
        {
            try
            {
                var allUsers = await _userManager.Users.ToListAsync();

                var vms = new List<AdminUserVm>();

                foreach (var user in allUsers)
                {
                    vms.Add(new AdminUserVm
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        Email = user.Email,
                        Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault()
                    });
                }

                return View(vms);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"An error occurred while loading users: {ex.Message}";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}