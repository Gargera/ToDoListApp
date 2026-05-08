using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoListApp.BLL.Interfaces;
using ToDoListApp.PL.Mapping;
using ToDoListApp.PL.Models;
using ToDoListApp.PL.ViewModels.HomeVms;
using ToDoListApp.PL.ViewModels.ToDoItemVms;

namespace ToDoListApp.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IToDoItemService _toDoItemService;

        public HomeController(IToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }

        public IActionResult Index()
        {
            var allToDoItems = _toDoItemService.GetAllToDoItemsDtos()
                                               .Select(t => t.EntityToGetToDoItemVm())
                                               .ToList();

            var homeIndexVm = new HomeIndexVm
            {
                TotalTasks = allToDoItems.Count,
                CompletedTasks = allToDoItems.Count(x => x.IsCompleted),
                PendingTasks = allToDoItems.Count(x => !x.IsCompleted)
            };

            return View(homeIndexVm);
        }

        public IActionResult Privacy()
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
