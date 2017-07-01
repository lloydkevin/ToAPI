using System.Collections.Generic;
using TodoAPI.Model;

namespace TodoAPI.Data
{
    public interface ITodoRepository
    {
        IEnumerable<TodoItem> GetAll();
        void Add(TodoItem todoItem);
        TodoItem Get(long id);
        TodoItem Update(TodoItem item);
    }
}