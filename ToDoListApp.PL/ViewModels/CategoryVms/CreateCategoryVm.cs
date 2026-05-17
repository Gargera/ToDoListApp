using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.PL.ViewModels.CategoryVms
{
    public class CreateCategoryVm
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string Name { get; set; } = null!;

        [MaxLength(100)]
        public string? Description { get; set; }

        public bool IsSystem { get; set; } = false;
    }
}
