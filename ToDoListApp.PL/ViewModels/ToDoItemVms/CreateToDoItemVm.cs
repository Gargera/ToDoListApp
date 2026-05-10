using System.ComponentModel.DataAnnotations;
using ToDoListApp.DAL.Entities;

namespace ToDoListApp.PL.ViewModels.ToDoItemVms
{
    public class CreateToDoItemVm
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters.")]
        public string Title { get; set; }

        [MaxLength(200, ErrorMessage = "Description cannot exceed 200 characters.")]
        public string? Description { get; set; }

        public bool IsCompleted { get; set; }

        [EnumDataType(typeof(Priority), ErrorMessage = "Please select a valid priority.")]
        public Priority Priority { get; set; }
    }
}
