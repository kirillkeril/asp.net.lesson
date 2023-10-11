using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private readonly ApplicationContext _appContext;

    public TodoController(ApplicationContext appContext)
    {
        _appContext = appContext;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_appContext.Todos);
    }

    [HttpPost]
    public IActionResult Create(CreateTodoDto todoDto)
    {
        var newTodo = new Todo() { Title = todoDto.Title, IsCompleted = todoDto.IsCompleted};
        return Ok(_appContext.Create(newTodo));
    }

    [HttpPatch]
    public IActionResult Update(int id, UpdateTodoDto dto)
    {
        try
        {
            return Ok(_appContext.Update(id, dto));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var res = _appContext.Delete(id);
        if (res == 0) return NoContent();

        if (res == -1) return NotFound();
        return Problem();
    }
}
