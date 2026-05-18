using AutoMapper;
using ToDoListApp.BLL.DTOs;
using ToDoListApp.BLL.DTOs.ToDoItemDtos;
using ToDoListApp.PL.ViewModels.ToDoItemVms;
using ToDoListApp.BLL.DTOs.CategoryDtos;
using ToDoListApp.PL.ViewModels.CategoryVms;
using ToDoListApp.DAL.Entities;
using ToDoListApp.PL.ViewModels.AccountVms;

namespace ToDoListApp.PL.Mapper
{
    public class DomainProfile : Profile
        {
            public DomainProfile()
            {
                CreateMap<GetCategoryDto, GetCategoryVm>().ReverseMap();
                CreateMap<CreateCategoryDto, CreateCategoryVm>().ReverseMap();
                CreateMap<UpdateCategoryDto, UpdateCategoryVm>().ReverseMap();
                CreateMap<GetCategoryDto, UpdateCategoryVm>().ReverseMap();
  
                CreateMap<GetToDoItemDto, GetToDoItemVm>().ReverseMap();
                CreateMap<CreateToDoItemDto, CreateToDoItemVm>().ReverseMap();
                CreateMap<UpdateToDoItemDto, UpdateToDoItemVm>().ReverseMap();
                CreateMap<GetToDoItemDto, UpdateToDoItemVm>().ReverseMap();

                CreateMap<CreateUserVm, ApplicationUser>().ReverseMap();
            }
        }
}
