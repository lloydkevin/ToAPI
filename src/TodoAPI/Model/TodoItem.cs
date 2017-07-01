using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Model
{
    public class TodoItem
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
    }
}