using ToDoListApp.BLL.Common;
using ToDoListApp.BLL.DTOs.CategoryDtos;

namespace ToDoListApp.BLL.Services.Abstraction
{
    public interface ICategoryService
    {
        public Task<ResponseResult<List<GetCategoryDto>>> GetAllCategoriesDtosAsync();
        public Task<ResponseResult<GetCategoryDto>> GetCategoryDtoByIdAsync(int id);

        public Task<ResponseResult<CreateCategoryDto>> CreateCategoryAsync(CreateCategoryDto createCategoryDto);

        public Task<ResponseResult<int>> DeleteCategoryAsync(int id);

        public Task<ResponseResult<UpdateCategoryDto>> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);

        public Task<ResponseResult<bool>> CheckUniqueNameAsync(string name);
    }
}