using System;
using System.Collections.Generic;
using System.Text;
using ToDoListApp.DAL.Entities;

namespace ToDoListApp.DAL.Interfaces
{
    public interface IToDoItemRepo
    {
        public List<ToDoItem> GetAllToDoItems();

        public ToDoItem GetToDoItemById(int id);

        public void CreateToDoItem(ToDoItem toDoItem);

        public void DeleteToDoItem(int id);

        public void UpdateToDoItem(ToDoItem toDoItem);
    }
}
