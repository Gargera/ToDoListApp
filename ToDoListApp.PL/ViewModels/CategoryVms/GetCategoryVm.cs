using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoListApp.DAL.Entities;
using ToDoListApp.PL.ViewModels.ToDoItemVms;

namespace ToDoListApp.PL.ViewModels.CategoryVms
{
    public class GetCategoryVm
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool IsSystem { get; set; } = false;

        public string UserId { get; set; } = null!;

        public ICollection<GetToDoItemVm> ToDoItems { get; set; } = new List<GetToDoItemVm>();
    }
}
