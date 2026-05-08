using System;
using System.Collections.Generic;
using System.Text;
using ToDoListApp.BLL.DTOs.ToDoItemDtos;
using ToDoListApp.BLL.Interfaces;
using ToDoListApp.BLL.Mapping;
using ToDoListApp.DAL.Interfaces;

namespace ToDoListApp.BLL.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IToDoItemRepo _toDoItemRepo;

        public ToDoItemService(IToDoItemRepo toDoItemRepo)
        {
            _toDoItemRepo = toDoItemRepo;
        }

        public List<GetToDoItemDto> GetAllToDoItemsDtos()
        {
            return _toDoItemRepo.GetAllToDoItems().Select(t => t.EntityToGetToDoItemDto()).ToList();
        }

        public GetToDoItemDto GetToDoItemDtoById(int id)
        {
            var res = _toDoItemRepo.GetToDoItemById(id);

            if(res == null)
            {
                throw new Exception($"There's no ToDoItem with id = {id}");
            }
            else
            {
                return res.EntityToGetToDoItemDto();
            }
        }

        public void CreateToDoItem(CreateToDoItemDto createToDoItemDto)
        {
            _toDoItemRepo.CreateToDoItem(createToDoItemDto.EntityToToDoItem());
        }

        public void DeleteToDoItem(int id)
        {
            _toDoItemRepo.DeleteToDoItem(id);
        }

        public void UpdateToDoItem(UpdateToDoItemDto updateToDoItemDto)
        {
            _toDoItemRepo.UpdateToDoItem(updateToDoItemDto.EntityToToDoItem());
        }
    }
}
