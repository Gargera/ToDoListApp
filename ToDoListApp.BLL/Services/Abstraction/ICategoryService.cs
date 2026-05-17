using ToDoListApp.BLL.Common;
using ToDoListApp.BLL.DTOs.CategoryDtos;
using ToDoListApp.DAL.Entities;

namespace ToDoListApp.BLL.Services.Abstraction
{
    public interface ICategoryService
    {
        public Task<ResponseResult<List<GetCategoryDto>>> GetAllCategoriesDtosByUserIdAsync(string userId);

        public Task<ResponseResult<GetCategoryDto>> GetCategoryDtoByIdAsync(int id);

        public Task<ResponseResult<CreateCategoryDto>> CreateCategoryDtoAsync(CreateCategoryDto createCategoryDto);

        public Task<ResponseResult<string>> CreateDefaultCategoryAsync(string UserId);

        public Task<ResponseResult<int>> DeleteCategoryDtoAsync(int id);

        public Task<ResponseResult<UpdateCategoryDto>> UpdateCategoryDtoAsync(UpdateCategoryDto updateCategoryDto);

        public Task<ResponseResult<bool>> CheckCategoryUniqueNameAsync(string name);
    }
}