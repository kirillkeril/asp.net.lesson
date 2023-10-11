namespace WebApplication1.Models;

public record UpdateTodoDto(
    string? Title,
    bool? IsCompleted
);
