using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ToDoListApp.DAL.Entities;
using ToDoListApp.DAL.Enums;

namespace ToDoListApp.BLL.DTOs.CategoryDtos
{
    public class GetCategoryDto
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

        public ICollection<ToDoItem> ToDoItems { get; set; } = new List<ToDoItem>();
    }
}
