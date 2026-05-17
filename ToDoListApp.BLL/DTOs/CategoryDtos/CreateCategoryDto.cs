using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ToDoListApp.DAL.Entities;
using ToDoListApp.DAL.Enums;

namespace ToDoListApp.BLL.DTOs.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; } = null!;

        public bool IsSystem { get; set; } = false;

        public string UserId { get; set; } = null!;
    }
}
