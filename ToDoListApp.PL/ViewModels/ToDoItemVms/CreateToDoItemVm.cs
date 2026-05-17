using System.ComponentModel.DataAnnotations;
using ToDoListApp.DAL.Enums;

namespace ToDoListApp.PL.ViewModels.ToDoItemVms
{
    public class CreateToDoItemVm
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 50 characters.")]
        public string Title { get; set; } = null!;

        [MaxLength(400, ErrorMessage = "Description cannot exceed 400 characters.")]
        public string? Description { get; set; }

        public bool IsCompleted { get; set; } = false;
        
        [EnumDataType(typeof(Priority))]
        public Priority Priority { get; set; } = Priority.High;

        public int CategoryId { get; set; }
    }
}
