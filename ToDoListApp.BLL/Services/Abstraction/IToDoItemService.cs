using System.Linq.Expressions;
using ToDoListApp.BLL.Common;
using ToDoListApp.BLL.DTOs.ToDoItemDtos;
using ToDoListApp.DAL.Entities;

namespace ToDoListApp.BLL.Services.Abstraction
{
    public interface IToDoItemService
    {
        public Task<ResponseResult<List<GetToDoItemDto>>> GetAllToDoItemDtosByCategoryIdAsync(int categoryId);

        public Task<ResponseResult<GetToDoItemDto>> GetToDoItemDtoByIdAsync(int id);

        public Task<ResponseResult<CreateToDoItemDto>> CreateToDoItemDtoAsync(CreateToDoItemDto createToDoItemDto);

        public Task<ResponseResult<int>> DeleteToDoItemDtoAsync(int id);
        
        public Task<ResponseResult<UpdateToDoItemDto>> UpdateToDoItemDtoAsync(UpdateToDoItemDto updateToDoItemDto);

        public Task<ResponseResult<bool>> CheckToDoItemUniqueTitleAsync(Expression<Func<ToDoItem, bool>> predicate);

        public Task<ResponseResult<int>> CountByUserIdAsync(string userId);

        public Task<ResponseResult<int>> CountCompletedByUserIdAsync(string userId);
    }
}
