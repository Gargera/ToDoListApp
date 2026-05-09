using ToDoListApp.BLL.DTOs.ToDoItemDtos;
using ToDoListApp.DAL.Entities;
using ToDoListApp.PL.ViewModels.ToDoItemVms;
using ToDoListApp.PL.ViewModels.AuthVms;

namespace ToDoListApp.PL.Mapping
{
    public static class UserMapping
    {
        public static ApplicationUser EntityToApplicationUser(this CreateUserVm createUserVm)
        {
            return new ApplicationUser
            {
                UserName = createUserVm.UserName,
                Email = createUserVm.Email
            };
        }
        public static ApplicationUser EntityToApplicationUser(this LogInUserVm logInUserVm)
        {
            return new ApplicationUser
            {
                UserName = logInUserVm.UserName,
            };
        }
    }
}
