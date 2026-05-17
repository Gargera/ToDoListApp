using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoListApp.PL.ViewModels.CategoryVms;
using ToDoListApp.DAL.Enums;

namespace ToDoListApp.PL.ViewModels.ToDoItemVms
{
    public class GetToDoItemVm
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 50 characters.")]
        public string Title { get; set; } = null!;

        [MaxLength(400, ErrorMessage = "Description cannot exceed 400 characters.")]
        public string? Description { get; set; }

        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [EnumDataType(typeof(Priority))]
        public Priority Priority { get; set; } = Priority.High;

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public GetCategoryVm Category { get; set; } = null!;
    }
}
