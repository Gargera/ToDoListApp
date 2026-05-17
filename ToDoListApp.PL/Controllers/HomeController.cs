using System.Diagnostics;
using ToDoListApp.PL.Models;
using ToDoListApp.PL.ViewModels.HomeVms;

namespace ToDoListApp.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IToDoItemService _toDoItemService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(IToDoItemService toDoItemService, ICategoryService categoryService, UserManager<ApplicationUser> userManager)
        {
            _toDoItemService = toDoItemService;
            _categoryService = categoryService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                HomeVm homeVm = new HomeVm
                {
                    TotalTasks = 0,
                    CompletedTasks = 0,
                    PendingTasks = 0
                };

                var userId = _userManager.GetUserId(User);
                if (userId == null) return View(homeVm);

                var totResult = await _toDoItemService.CountByUserIdAsync(userId);
                if (!totResult.IsSuccess) return View(homeVm);

                var compResult = await _toDoItemService.CountCompletedByUserIdAsync(userId);
                if (!compResult.IsSuccess) return View(homeVm);

                var pendResult = totResult.Data - compResult.Data;

                homeVm.TotalTasks = totResult.Data;
                homeVm.CompletedTasks = compResult.Data;
                homeVm.PendingTasks = pendResult;
                return View(homeVm);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
