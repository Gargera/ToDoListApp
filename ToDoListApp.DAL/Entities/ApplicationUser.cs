using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDoListApp.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}