using ToDoListApp.BLL.DTOs.CategoryDtos;

namespace ToDoListApp.PL.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        private readonly IMapper _mapper;

        private readonly UserManager<ApplicationUser> _userManager;

        public CategoryController(ICategoryService categoryService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var userId = _userManager.GetUserId(User);
                
                var getCategories = await _categoryService.GetAllCategoriesDtosByUserIdAsync(userId);
                if (!getCategories.IsSuccess) return BadRequest(getCategories.Message);

                var mappedResult = _mapper.Map<List<GetCategoryVm>>(getCategories.Data);
                return View(mappedResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryVm createCategoryVm)
        {
            try
            {
                if (!ModelState.IsValid) return View(createCategoryVm);

                var userId = _userManager.GetUserId(User);
                
                var checkUniqueName = await _categoryService.CheckCategoryUniqueNameAsync(c => c.Name == createCategoryVm.Name && c.UserId == userId);
                if (!checkUniqueName.IsSuccess)
                {
                    ModelState.AddModelError("Name", checkUniqueName.Message);
                    return View(createCategoryVm);
                }

                var mappedResult = _mapper.Map<CreateCategoryDto>(createCategoryVm);
                mappedResult.UserId = userId;
                var result = await _categoryService.CreateCategoryDtoAsync(mappedResult);
                if (!result.IsSuccess)
                {
                    ModelState.AddModelError("", result.Message);
                    return View(createCategoryVm);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An unexpected error occurred: {ex.Message}");
                return View(createCategoryVm);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var category = await _categoryService.GetCategoryDtoByIdAsync(id);
                if (!category.IsSuccess) return NotFound(category.Message);

                var vm = _mapper.Map<UpdateCategoryVm>(category.Data);
                return View(vm);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryVm updateCategoryVm)
        {
            try
            {
                var userId = _userManager.GetUserId(User);
                
                updateCategoryVm.Id = ViewData["CategoryId"] != null ? (int)ViewData["CategoryId"] : updateCategoryVm.Id;
                if (!ModelState.IsValid) return View(updateCategoryVm);

                var checkUniqueName = await _categoryService.CheckCategoryUniqueNameAsync(c => c.Name == updateCategoryVm.Name && 
                                                                                               c.UserId == userId &&
                                                                                               c.Id != updateCategoryVm.Id); //maybe user didn't change the Name :)
                if (!checkUniqueName.IsSuccess)
                {
                    ModelState.AddModelError("Name", checkUniqueName.Message);
                    return View(updateCategoryVm);
                }

                var mappedResult = _mapper.Map<UpdateCategoryDto>(updateCategoryVm);
                mappedResult.UserId = userId;
                var result = await _categoryService.UpdateCategoryDtoAsync(mappedResult);
                if (!result.IsSuccess)
                {
                    ModelState.AddModelError("", result.Message);
                    return View(updateCategoryVm);
                }

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", $"An unexpected error occurred: {ex.Message}");
                return View(updateCategoryVm);
            }
        }

        public async Task<IActionResult> Delete(int categoryId)
        {
            try
            {
                var category = await _categoryService.GetCategoryDtoByIdAsync(categoryId);
                if(!category.IsSuccess) return NotFound(category.Message);

                var userId = _userManager.GetUserId(User);
                if (userId != category.Data.UserId) return Forbid("You are not authorized to update this category.");

                var result = await _categoryService.DeleteCategoryDtoAsync(categoryId);
                if (!result.IsSuccess)
                {
                    ModelState.AddModelError("", result.Message);
                }

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", $"An unexpected error occurred: {ex.Message}");
                return RedirectToAction("Index");
            }
        }
    }
}