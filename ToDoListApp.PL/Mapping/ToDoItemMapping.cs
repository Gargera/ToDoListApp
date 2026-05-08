using ToDoListApp.BLL.DTOs.ToDoItemDtos;
using ToDoListApp.DAL.Entities;
using ToDoListApp.PL.ViewModels.ToDoItemVms;

namespace ToDoListApp.PL.Mapping
{
    public static class ToDoItemMapping
    {
        public static GetToDoItemDto EntityToGetToDoItemDto(this GetToDoItemVm getToDoItemVm)
        {
            return new GetToDoItemDto
            {
                Id = getToDoItemVm.Id,
                Title = getToDoItemVm.Title,
                Description = getToDoItemVm.Description,
                IsCompleted = getToDoItemVm.IsCompleted,
                CreatedDate = getToDoItemVm.CreatedDate,
                Priority = getToDoItemVm.Priority
            };
        }

        public static CreateToDoItemDto EntityToCreateToDoItemDto(this CreateToDoItemVm createToDoItemVm)
        {
            return new CreateToDoItemDto
            {
                Title = createToDoItemVm.Title,
                Description = createToDoItemVm.Description,
                IsCompleted = createToDoItemVm.IsCompleted,
                Priority = createToDoItemVm.Priority
            };
        }

        public static GetToDoItemVm EntityToGetToDoItemVm(this GetToDoItemDto getToDoItemDto)
        {
            return new GetToDoItemVm
            {
                Id = getToDoItemDto.Id,
                Title = getToDoItemDto.Title,
                Description = getToDoItemDto.Description,
                IsCompleted = getToDoItemDto.IsCompleted,
                CreatedDate = getToDoItemDto.CreatedDate,
                Priority = getToDoItemDto.Priority
            };
        }

        public static CreateToDoItemVm EntityToCreateToDoItemVm(this CreateToDoItemDto createToDoItemDto)
        {
            return new CreateToDoItemVm
            {
                Title = createToDoItemDto.Title,
                Description = createToDoItemDto.Description,
                IsCompleted = createToDoItemDto.IsCompleted,
                Priority = createToDoItemDto.Priority
            };
        }

        public static UpdateToDoItemVm EntityToUpdateToDoItemVm(this GetToDoItemDto getToDoItemDto)
        {
            return new UpdateToDoItemVm
            {
                Id = getToDoItemDto.Id,
                Title = getToDoItemDto.Title,
                Description = getToDoItemDto.Description,
                IsCompleted = getToDoItemDto.IsCompleted,
                CreatedDate = getToDoItemDto.CreatedDate,
                Priority = getToDoItemDto.Priority
            };
        }

        public static UpdateToDoItemDto EntityToUpdateToDoItemDto(this UpdateToDoItemVm updateToDoItemVm)
        {
            return new UpdateToDoItemDto
            {
                Id = updateToDoItemVm.Id,
                Title = updateToDoItemVm.Title,
                Description = updateToDoItemVm.Description,
                IsCompleted = updateToDoItemVm.IsCompleted,
                CreatedDate = updateToDoItemVm.CreatedDate,
                Priority = updateToDoItemVm.Priority
            };
        }
    }
}