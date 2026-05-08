using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ToDoListApp.DAL.Entities
{
    public class ToDoItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [EnumDataType(typeof(Priority))]
        public Priority Priority { get; set; }
    }
}
