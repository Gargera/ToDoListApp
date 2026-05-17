using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoListApp.DAL.Entities;
using ToDoListApp.PL.ViewModels.ToDoItemVms;

namespace ToDoListApp.PL.ViewModels.CategoryVms
{
    public class GetCategoryVm
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Description { get; set; } = null!;

        public bool IsSystem { get; set; } = false;

        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        public ICollection<GetToDoItemVm> ToDoItems { get; set; } = new List<GetToDoItemVm>();
    }
}
