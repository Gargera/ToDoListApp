using System.ComponentModel.DataAnnotations;
using ToDoListApp.DAL.Entities;

namespace ToDoListApp.PL.ViewModels.ToDoItemVms
{
    public class UpdateToDoItemVm
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime CreatedDate { get; set; }

        [EnumDataType(typeof(Priority))]
        public Priority Priority { get; set; }
    }
}
