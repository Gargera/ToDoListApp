using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.DAL.Entities
{
    public class Category : BaseEntity<int>
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        public ICollection<ToDoItem> ToDoItems { get; set; } = new List<ToDoItem>();
    }
}
