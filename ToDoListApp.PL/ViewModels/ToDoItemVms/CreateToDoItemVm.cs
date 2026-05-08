using System.ComponentModel.DataAnnotations;
using ToDoListApp.DAL.Entities;

namespace ToDoListApp.PL.ViewModels.ToDoItemVms
{
    public class CreateToDoItemVm
    {
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        public bool IsCompleted { get; set; }

        [EnumDataType(typeof(Priority))]
        public Priority Priority { get; set; }
    }
}
