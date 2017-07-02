using Microsoft.EntityFrameworkCore;

namespace TodoAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TodoDataContext dataContext)
        {
            dataContext.Database.EnsureCreated();
            dataContext.Database.Migrate();
        }
    }
}