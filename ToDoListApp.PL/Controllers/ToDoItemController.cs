using Microsoft.AspNetCore.Mvc;
using ToDoListApp.BLL.Interfaces;
using ToDoListApp.PL.Mapping;
using ToDoListApp.PL.ViewModels.ToDoItemVms;

namespace ToDoListApp.PL.Controllers
{
    public class ToDoItemController : Controller
    {
        private readonly IToDoItemService _toDoItemService;

        public ToDoItemController(IToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateToDoItemVm createToDoItemVm)
        {
            _toDoItemService.CreateToDoItem(createToDoItemVm.EntityToCreateToDoItemDto());
            return RedirectToAction("GetAll");
        }

        public IActionResult GetAll()
        {
            var allToDoItems = _toDoItemService.GetAllToDoItemsDtos().Select(t => t.EntityToGetToDoItemVm());
            return View(allToDoItems);
        }

        public IActionResult Delete(int id)
        {
            _toDoItemService.DeleteToDoItem(id);

            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var updateToDoItemVm = _toDoItemService.GetToDoItemDtoById(id).EntityToUpdateToDoItemVm();

            return View("Update", updateToDoItemVm);
        }

        [HttpPost]
        public IActionResult Update(UpdateToDoItemVm updateToDoItemVm)
        {
            _toDoItemService.UpdateToDoItem(updateToDoItemVm.EntityToUpdateToDoItemDto());

            return RedirectToAction("GetAll");
        }
    }
}