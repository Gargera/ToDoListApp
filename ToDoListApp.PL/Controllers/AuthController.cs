using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoListApp.DAL.Entities;
using ToDoListApp.PL.Mapping;
using ToDoListApp.PL.ViewModels.AuthVms;

namespace ToDoListApp.PL.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateUserVm createUserVm)
        {
            var user = createUserVm.EntityToApplicationUser();
            var result = await _userManager.CreateAsync(user, createUserVm.Password);

            if(result.Succeeded)
                 return RedirectToAction("LogIn");
            else
                return View(createUserVm);
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInUserVm logInUserVm)
        {
            var user = logInUserVm.EntityToApplicationUser();
            var result = await _signInManager.CheckPasswordSignInAsync(user, logInUserVm.Password, false);

            if (result.Succeeded)
                return RedirectToPage("Home");
            else
                return View(logInUserVm);
        }
    }
}
