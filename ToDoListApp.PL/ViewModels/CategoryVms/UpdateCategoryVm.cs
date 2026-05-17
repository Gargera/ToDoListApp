using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListApp.PL.ViewModels.CategoryVms
{
    public class UpdateCategoryVm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string Name { get; set; } = null!;

        [MaxLength(100)]
        public string? Description { get; set; }

        public bool IsSystem { get; set; } = false;
    }
}
