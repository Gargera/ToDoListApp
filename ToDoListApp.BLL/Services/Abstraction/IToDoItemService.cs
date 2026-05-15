using ToDoListApp.BLL.Common;
using ToDoListApp.BLL.DTOs.ToDoItemDtos;
using ToDoListApp.DAL.Entities;

namespace ToDoListApp.BLL.Services.Abstraction
{
    public interface IToDoItemService
    {
        public Task<ResponseResult<List<GetToDoItemDto>>> GetAllToDoItemsDtosAsync();
        public Task<ResponseResult<GetToDoItemDto>> GetToDoItemDtoByIdAsync(int id);

        public Task<ResponseResult<CreateToDoItemDto>> CreateToDoItemAsync(CreateToDoItemDto createToDoItemDto);

        public Task<ResponseResult<int>> DeleteToDoItemAsync(int id);
        
        public Task<ResponseResult<UpdateToDoItemDto>> UpdateToDoItemAsync(UpdateToDoItemDto updateToDoItemDto);

        public Task<ResponseResult<bool>> CheckUniqueTitleAsync(string title);    }
}
