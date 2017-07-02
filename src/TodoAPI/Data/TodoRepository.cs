using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Model;

namespace TodoAPI.Data
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDataContext _dataContext;
        public TodoRepository(TodoDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(TodoItem todoItem)
        {
            _dataContext.Add(todoItem);
            _dataContext.SaveChanges();
        }

        public void Delete(TodoItem item)
        {
            _dataContext.Remove(item);
            _dataContext.SaveChanges();
        }

        public TodoItem Get(long id)
        {
            return _dataContext.TodoItem.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _dataContext.TodoItem.AsNoTracking().ToList();
        }

        public TodoItem Update(TodoItem item)
        {
            _dataContext.Update(item);
            _dataContext.SaveChanges();
            return item;
        }
    }
}