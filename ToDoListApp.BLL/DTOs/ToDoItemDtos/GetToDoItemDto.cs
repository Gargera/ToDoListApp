using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoListApp.BLL.DTOs.CategoryDtos;
using ToDoListApp.DAL.Enums;

namespace ToDoListApp.BLL.DTOs.ToDoItemDtos
{
    public class GetToDoItemDto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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
        public GetCategoryDto Category { get; set; } = null!;
    }
}
