using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ToDoListApp.DAL.Entities;

namespace ToDoListApp.BLL.DTOs.ToDoItemDtos
{
    public class CreateToDoItemDto
    {
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; } = null!;

        [MaxLength(200)]
        public string? Description { get; set; }

        public bool IsCompleted { get; set; }

        [EnumDataType(typeof(Priority))]
        public Priority Priority { get; set; }
    }
}
