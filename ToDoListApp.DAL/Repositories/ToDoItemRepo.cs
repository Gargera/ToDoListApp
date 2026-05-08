using System;
using System.Collections.Generic;
using System.Text;
using ToDoListApp.DAL;
using ToDoListApp.DAL.Interfaces;
using ToDoListApp.DAL.Entities;

namespace ToDoListApp.DAL.Repositories
{
    public class ToDoItemRepo : IToDoItemRepo
    {
        private readonly ToDoListAppDbContext _toDoListAppDbContext;

        public ToDoItemRepo(ToDoListAppDbContext toDoListAppDbContext)
        {
            _toDoListAppDbContext = toDoListAppDbContext;
        }

        public List<ToDoItem> GetAllToDoItems()
        {
            return _toDoListAppDbContext.toDoItems.ToList();
        }

        public ToDoItem? GetToDoItemById(int id)
        {
            return _toDoListAppDbContext.toDoItems.Find(id);
        }

        public void CreateToDoItem(ToDoItem toDoItem)
        {
            _toDoListAppDbContext.toDoItems.Add(toDoItem);
            _toDoListAppDbContext.SaveChanges();
        }

        public void DeleteToDoItem(int id)
        {
            var t = GetToDoItemById(id);

            _toDoListAppDbContext.Remove(t);
            _toDoListAppDbContext.SaveChanges();
        }

        public void UpdateToDoItem(ToDoItem toDoItem)
        {
            _toDoListAppDbContext.toDoItems.Update(toDoItem);
            _toDoListAppDbContext.SaveChanges();
        }
    }
}
