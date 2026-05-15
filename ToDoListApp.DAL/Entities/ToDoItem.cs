using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListApp.DAL.Entities
{
    public class ToDoItem : BaseEntity<int>
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; } = null!;

        [MaxLength(400)]
        public string? Description { get; set; }

        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [EnumDataType(typeof(Priority))]
        public Priority Priority { get; set; } = Priority.High;

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;
    }
}
