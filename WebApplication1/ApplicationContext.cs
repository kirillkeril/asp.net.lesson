using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1;

public class ApplicationContext : DbContext
{
    private int _id = 0;
    public List<Todo> Todos = new();

    public Todo Create(Todo newTodo)
    {
        newTodo.Id = _id++;
        Todos.Add(newTodo);
        return newTodo;
    }

    public Todo Update(int id, UpdateTodoDto dto)
    {
        var todo = Todos.FirstOrDefault(t => t.Id == id);
        if (todo is null) throw new Exception("Нет такого элемента");

        todo.Title = dto.Title ?? todo.Title;
        todo.IsCompleted = dto.IsCompleted ?? todo.IsCompleted;

        return todo;
    }

    public int Delete(int id)
    {
        var todo = Todos.FirstOrDefault(t => t.Id == id);
        if (todo == null) return -1;

        Todos.Remove(todo);
        return 0;
    }
}
