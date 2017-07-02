using Microsoft.AspNetCore.Mvc;
using TodoAPI.Data;
using TodoAPI.Model;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoRepository _repository;
        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var items = _repository.GetAll();
            return Ok(items);
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            var item = _repository.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody]TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _repository.Add(item);
            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody]TodoItem item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var result = _repository.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var item = _repository.Get(id);
            if (item == null)
            {
                return BadRequest();
            }

            _repository.Delete(item);
            return new NoContentResult();
        }
    }
}