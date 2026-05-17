using ToDoListApp.BLL.DTOs.CategoryDtos;

namespace ToDoListApp.PL.Controllers
{
    [Authorize(Roles = "User")]
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
                if(userId == null) return NotFound("User not found");

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

                var checkUniqueName = await _categoryService.CheckCategoryUniqueNameAsync(createCategoryVm.Name);
                if (!checkUniqueName.IsSuccess)
                {
                    ModelState.AddModelError("Name", checkUniqueName.Message);
                    return View(createCategoryVm);
                }

                var userId = _userManager.GetUserId(User);
                if (userId == null) return NotFound("User not found");
                createCategoryVm.UserId = userId;

                var mappedResult = _mapper.Map<CreateCategoryDto>(createCategoryVm);
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
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryVm updateCategoryVm)
        {
            try
            {
                if (!ModelState.IsValid) return View(updateCategoryVm);

                var mappedResult = _mapper.Map<UpdateCategoryDto>(updateCategoryVm);
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