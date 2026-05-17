using AutoMapper;
using ToDoListApp.DAL.Entities;
using ToDoListApp.BLL.DTOs.ToDoItemDtos;
using ToDoListApp.BLL.DTOs.CategoryDtos;

namespace ToDoListApp.BLL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<ToDoItem, GetToDoItemDto>();
            CreateMap<CreateToDoItemDto, ToDoItem>();
            CreateMap<UpdateToDoItemDto, ToDoItem>();
            
            CreateMap<Category, GetCategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
        }
    }
}
