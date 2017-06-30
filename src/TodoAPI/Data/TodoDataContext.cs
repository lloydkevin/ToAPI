using Microsoft.EntityFrameworkCore;
using TodoAPI.Model;

namespace TodoAPI.Data
{
    public class TodoDataContext : DbContext
    {
        public TodoDataContext(DbContextOptions options) : base( options)
        {
        }
        public DbSet<TodoItem> ToTodoItem { get; set; }
    }
}
