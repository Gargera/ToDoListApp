using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoListApp.BLL.DTOs.ToDoItemDtos;
using ToDoListApp.DAL.Entities;
using ToDoListApp.DAL.Enums;

namespace ToDoListApp.BLL.DTOs.CategoryDtos
{
    public class GetCategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; } = null!;

        public bool IsSystem { get; set; } = false;

        public string UserId { get; set; } = null!;

        public ApplicationUser User { get; set; } = null!;

        public List<GetToDoItemDto> ToDoItems { get; set; } = new List<GetToDoItemDto>();
    }
}
