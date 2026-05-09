using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ToDoListApp.DAL.Entities;

namespace ToDoListApp.DAL
{
    public class ToDoListAppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }

        public ToDoListAppDbContext(DbContextOptions<ToDoListAppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoItem>(entity =>
            {
                entity.ToTable(t =>
                {
                    t.HasCheckConstraint(
                        "CK_TodoItem_Title_Length",
                        "LEN(Title) BETWEEN 3 AND 100");

                    t.HasCheckConstraint(
                        "CK_TodoItem_Description_Length",
                        "Description IS NULL OR LEN(Description) <= 200");

                    t.HasCheckConstraint(
                        "CK_TodoItem_Priority",
                        "Priority IN (0, 1, 2)");
                });
            });

            modelBuilder.Entity<ToDoItem>()
                    .HasOne(t => t.User)
                    .WithMany(u => u.ToDoItems)
                    .HasForeignKey(t => t.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
