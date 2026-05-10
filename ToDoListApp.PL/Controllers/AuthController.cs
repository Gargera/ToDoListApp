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
            if (!ModelState.IsValid)
                return View(createUserVm);

            var existingUserByEmail = await _userManager.FindByEmailAsync(createUserVm.Email);
            if (existingUserByEmail != null)
            {
                ModelState.AddModelError("Email", "This email is already registered. Please use a different email.");
                return View(createUserVm);
            }

            var existingUserByUsername = await _userManager.FindByNameAsync(createUserVm.UserName);
            if (existingUserByUsername != null)
            {
                ModelState.AddModelError("UserName", "This username is already taken. Please choose a different one.");
                return View(createUserVm);
            }

            var user = createUserVm.EntityToApplicationUser();
            var result = await _userManager.CreateAsync(user, createUserVm.Password);

            if (result.Succeeded)
                return RedirectToAction("LogIn");
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(createUserVm);
            }
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInUserVm logInUserVm)
        {
            if (!ModelState.IsValid)
                return View(logInUserVm);

            var user = await _userManager.FindByNameAsync(logInUserVm.UserName);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password. Please try again.");
                return View(logInUserVm);
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, logInUserVm.Password, false);

            if (result.Succeeded)
                return RedirectToAction("Index", "Home");
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password. Please try again.");
                return View(logInUserVm);
            }
        }
    }
}
