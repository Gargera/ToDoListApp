using Microsoft.AspNetCore.Authorization;
using ToDoListApp.BLL.DTOs.ToDoItemDtos;

namespace ToDoListApp.PL.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class ToDoItemController : Controller
    {
        private readonly IToDoItemService _toDoItemService;

        private readonly ICategoryService _categoryService;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IMapper _mapper;

        public ToDoItemController(IToDoItemService toDoItemService, ICategoryService categoryService, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _toDoItemService = toDoItemService;
            _categoryService = categoryService;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int CategoryId)
        {
            try
            {
                var category = await _categoryService.GetCategoryDtoByIdAsync(CategoryId);
                if(!category.IsSuccess) return NotFound(category.Message);

                var allToDoItems = await _toDoItemService.GetAllToDoItemDtosByCategoryIdAsync(CategoryId);
                if(!allToDoItems.IsSuccess) return NotFound(allToDoItems.Message);

                var mappedCategory = _mapper.Map<GetCategoryVm>(category.Data);
                ViewBag.Category = mappedCategory;

                var mappedToDoItems = _mapper.Map<List<GetToDoItemVm>>(allToDoItems.Data);
                return View(mappedToDoItems);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var userId = _userManager.GetUserId(User);

                var allToDoItems = await _toDoItemService.GetAllToDoItemDtosByUserIdAsync(userId);
                if (!allToDoItems.IsSuccess) return NotFound(allToDoItems.Message);

                var mappedToDoItems = _mapper.Map<List<GetToDoItemVm>>(allToDoItems.Data);

                return View(mappedToDoItems);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create(int CategoryId)
        {
            try
            {
                var category = await _categoryService.GetCategoryDtoByIdAsync(CategoryId);
                if (!category.IsSuccess) return NotFound(category.Message);

                var vm = new CreateToDoItemVm { CategoryId = CategoryId };

                return View(vm);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateToDoItemVm createToDoItemVm)
        {
            try
            {
                if (!ModelState.IsValid) return View(createToDoItemVm);

                var category = await _categoryService.GetCategoryDtoByIdAsync(createToDoItemVm.CategoryId);
                if (!category.IsSuccess) return NotFound(category.Message);

                var titleUnique = await _toDoItemService.CheckToDoItemUniqueTitleAsync(t => t.Title == createToDoItemVm.Title && t.CategoryId == createToDoItemVm.CategoryId);
                if (!titleUnique.IsSuccess)
                {
                    ModelState.AddModelError("Title", titleUnique.Message);
                    return View(createToDoItemVm);
                }

                var toDoItem = _mapper.Map<CreateToDoItemDto>(createToDoItemVm);
                var result = await _toDoItemService.CreateToDoItemDtoAsync(toDoItem);
                if (!result.IsSuccess)
                {
                    ModelState.AddModelError("", result.Message);
                    return View(createToDoItemVm);
                }

                return RedirectToAction("Index", new { CategoryId = createToDoItemVm.CategoryId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(createToDoItemVm);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var toDoItem = await _toDoItemService.GetToDoItemDtoByIdAsync(id);
                if (!toDoItem.IsSuccess) return NotFound(toDoItem.Message);

                var result = await _toDoItemService.DeleteToDoItemDtoAsync(id);
                if (!result.IsSuccess) return NotFound(result.Message);

                return RedirectToAction("Index", new { CategoryId = toDoItem.Data.CategoryId });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var toDoItem = await _toDoItemService.GetToDoItemDtoByIdAsync(id);
                if (!toDoItem.IsSuccess) return NotFound(toDoItem.Message);

                var vm = _mapper.Map<UpdateToDoItemVm>(toDoItem.Data);
                return View(vm);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateToDoItemVm updateToDoItemVm)
        {
            try
            {
                updateToDoItemVm.Id = ViewData["Id"] != null ? (int)ViewData["Id"] : updateToDoItemVm.Id;
                updateToDoItemVm.CategoryId = ViewData["CategoryId"] != null ? (int)ViewData["CategoryId"] : updateToDoItemVm.CategoryId;
                
                if (!ModelState.IsValid) return View(updateToDoItemVm);

                var category = await _categoryService.GetCategoryDtoByIdAsync(updateToDoItemVm.CategoryId);
                if (!category.IsSuccess) return NotFound(category.Message);

                var titleUnique = await _toDoItemService.CheckToDoItemUniqueTitleAsync(t => t.Title == updateToDoItemVm.Title && 
                                                                                            t.CategoryId == updateToDoItemVm.CategoryId && 
                                                                                            t.Id != updateToDoItemVm.Id); //maybe user didn't change the title :)
                if (!titleUnique.IsSuccess)
                {
                    ModelState.AddModelError("Title", titleUnique.Message);
                    return View(updateToDoItemVm);
                }

                var toDoItem = _mapper.Map<UpdateToDoItemDto>(updateToDoItemVm);
                var result = await _toDoItemService.UpdateToDoItemDtoAsync(toDoItem);
                if (!result.IsSuccess)
                {
                    ModelState.AddModelError("", result.Message);
                    return View(updateToDoItemVm);
                }

                return RedirectToAction("Index", new { CategoryId = updateToDoItemVm.CategoryId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(updateToDoItemVm);
            }
        }
    }
}