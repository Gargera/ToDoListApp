using System;
using System.Collections.Generic;
using System.Text;
using ToDoListApp.BLL.DTOs.ToDoItemDtos;

namespace ToDoListApp.BLL.Interfaces
{
    public interface IToDoItemService
    {
        public List<GetToDoItemDto> GetAllToDoItemsDtos();

        public GetToDoItemDto GetToDoItemDtoById(int id);

        public void CreateToDoItem(CreateToDoItemDto createToDoItemDto);

        public void DeleteToDoItem(int id);

        public void UpdateToDoItem(UpdateToDoItemDto updateToDoItemDto);
    }
}
