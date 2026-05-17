using System.Diagnostics;
using ToDoListApp.PL.Models;
using ToDoListApp.PL.ViewModels.HomeVms;

namespace ToDoListApp.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IToDoItemService _toDoItemService;
        private readonly ICategoryService _categoryService;

        public HomeController(IToDoItemService toDoItemService, ICategoryService categoryService)
        {
            _toDoItemService = toDoItemService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
