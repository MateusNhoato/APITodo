using ApiTodo.Context;
using ApiTodo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTodo.Controllers
{
    
    
    [Route("[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private AppDbContext _context;

        public TodosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Todo>> GetTodos()
        {
            try
            {
                var todos = _context.Todos;

                if (todos is null)
                    return NotFound();

                return todos;
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro no servidor.");
            }
        }

        [HttpGet("{id:int}")]
        public  ActionResult<Todo> GetTodo(int id) 
        {
            try
            {
                var todo = _context.Todos.FirstOrDefault(td => td.Id == id);

                if (todo is null)
                    return NotFound($"Todo com id={id} não foi encontrado.");

                return todo;
            }
            catch(Exception) 
            {
                return StatusCode(500, "Ocorreu um erro no servidor.");
            }
        }

        [HttpPost]
        public ActionResult Post(Todo todo) 
        {
            try
            {
                if (todo is null)
                    return BadRequest();

                _context.Todos.Add(todo);
                _context.SaveChanges();

                return StatusCode(201, todo);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro no servidor.");
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<Todo> Put(int id, Todo todoInput)
        {
            if (id != todoInput.Id)
                return BadRequest($"Id do request é diferente do Id do body.");

            var todo = _context.Todos.FirstOrDefault(td => td.Id == id);

            if (todo is null)
                return NotFound($"Todo com Id={id} não foi encontrado.");

            todo.Nome = todoInput.Nome;
            todo.Descricao = todoInput.Descricao;
            todo.Concluida = todoInput.Concluida;
            _context.SaveChanges();

            return Ok(todo);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id) 
        {
            try
            {
                var todo = _context.Todos.FirstOrDefault(td => td.Id == id);

                if (todo is null)
                    return NotFound($"Todo de id={id} não foi encontrado");

                _context.Todos.Remove(todo);
                _context.SaveChanges();
                return Ok(todo);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro no servidor.");
            }
        }
    }
}
