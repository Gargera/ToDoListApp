using System;
using System.Collections.Generic;
using System.Text;
using ToDoListApp.DAL.Entities;
using ToDoListApp.BLL.DTOs.ToDoItemDtos;

namespace ToDoListApp.BLL.Mapping
{
    public static class ToDoItemMapping
    {
        public static GetToDoItemDto EntityToGetToDoItemDto(this ToDoItem toDoItem)
        {
            return new GetToDoItemDto
            {
                Id = toDoItem.Id,
                Title = toDoItem.Title,
                Description = toDoItem.Description,
                IsCompleted = toDoItem.IsCompleted,
                CreatedDate = toDoItem.CreatedDate,
                Priority = toDoItem.Priority
            };
        }

        public static CreateToDoItemDto EntityToCreateToDoItemDto(this ToDoItem toDoItem)
        {
            return new CreateToDoItemDto
            {
                Title = toDoItem.Title,
                Description = toDoItem.Description,
                IsCompleted = toDoItem.IsCompleted,
                Priority = toDoItem.Priority
            };
        }

        public static ToDoItem EntityToToDoItem(this GetToDoItemDto getToDoItemDto)
        {
            return new ToDoItem
            {
                Id = getToDoItemDto.Id,
                Title = getToDoItemDto.Title,
                Description = getToDoItemDto.Description,
                IsCompleted = getToDoItemDto.IsCompleted,
                CreatedDate = getToDoItemDto.CreatedDate,
                Priority = getToDoItemDto.Priority
            };
        }

        public static ToDoItem EntityToToDoItem(this CreateToDoItemDto createToDoItemDto)
        {
            return new ToDoItem
            {
                Title = createToDoItemDto.Title,
                Description = createToDoItemDto.Description,
                IsCompleted = createToDoItemDto.IsCompleted,
                Priority = createToDoItemDto.Priority
            };
        }

        public static ToDoItem EntityToToDoItem(this UpdateToDoItemDto updateToDoItemDto)
        {
            return new ToDoItem
            {
                Id = updateToDoItemDto.Id,
                Title = updateToDoItemDto.Title,
                Description = updateToDoItemDto.Description,
                IsCompleted = updateToDoItemDto.IsCompleted,
                CreatedDate = updateToDoItemDto.CreatedDate,
                Priority = updateToDoItemDto.Priority
            };
        }
    }
}
