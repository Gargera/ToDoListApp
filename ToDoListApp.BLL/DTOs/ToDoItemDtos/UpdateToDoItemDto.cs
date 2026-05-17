using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoListApp.DAL.Enums;

namespace ToDoListApp.BLL.DTOs.ToDoItemDtos
{
    public class UpdateToDoItemDto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; } = null!;

        [MaxLength(400)]
        public string? Description { get; set; }

        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; }

        [EnumDataType(typeof(Priority))]
        public Priority Priority { get; set; }

        public int CategoryId { get; set; }
    }
}
