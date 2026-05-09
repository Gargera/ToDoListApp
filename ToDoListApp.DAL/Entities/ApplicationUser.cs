using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListApp.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<ToDoItem> ToDoItems { get; set; }
    }
}