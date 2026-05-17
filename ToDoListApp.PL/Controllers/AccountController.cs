using ToDoListApp.PL.ViewModels.AccountVms;

namespace ToDoListApp.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly ICategoryService _categoryService;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ICategoryService categoryService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateUserVm createUserVm)
        {
            try
            {
                if (!ModelState.IsValid) return View(createUserVm);

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

                var user = new ApplicationUser
                {
                    UserName = createUserVm.UserName,
                    Email = createUserVm.Email
                };
                var result = await _userManager.CreateAsync(user, createUserVm.Password);

                if (result.Succeeded)
                {
                    await _categoryService.CreateDefaultCategoryAsync(user.Id);
                    await _userManager.AddToRoleAsync(user, "User");
                    return RedirectToAction("LogIn");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(createUserVm);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred while creating the account: {ex.Message}");
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
            try
            {
                if (!ModelState.IsValid)
                    return View(logInUserVm);

                var user = await _userManager.FindByNameAsync(logInUserVm.UserName);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid username or password. Please try again.");
                    return View(logInUserVm);
                }

                var result = await _signInManager.PasswordSignInAsync(user, logInUserVm.Password, isPersistent: true, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid username or password. Please try again.");
                    return View(logInUserVm);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred while logging in: {ex.Message}");
                return View(logInUserVm);
            }
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("LogIn");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred while logging out: {ex.Message}");
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}