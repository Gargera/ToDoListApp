using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListApp.DAL.DataSeeding.Abstraction
{
    public interface IDataInitializer
    {
        public Task InitializeIdentityDataAsync();
    }
}
