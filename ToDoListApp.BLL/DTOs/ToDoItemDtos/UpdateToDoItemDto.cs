using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoListApp.DAL.Enums;

namespace ToDoListApp.BLL.DTOs.ToDoItemDtos
{
    public class UpdateToDoItemDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public bool IsCompleted { get; set; }

        public Priority Priority { get; set; }

        public int CategoryId { get; set; }
    }
}
