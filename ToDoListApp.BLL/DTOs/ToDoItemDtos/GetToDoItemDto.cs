using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoListApp.BLL.DTOs.CategoryDtos;
using ToDoListApp.DAL.Enums;

namespace ToDoListApp.BLL.DTOs.ToDoItemDtos
{
    public class GetToDoItemDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public Priority Priority { get; set; } = Priority.High;

        public int CategoryId { get; set; }

        public GetCategoryDto Category { get; set; } = null!;
    }
}
