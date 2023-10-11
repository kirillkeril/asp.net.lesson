using WebApplication1;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// Добавляем зависимости в контейнер

builder.Services.AddControllers();
// Добавляем сваггер (приколюха из которой можно смотреть и запускать запросы
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ApplicationContext>();

// Инстанс приложения
var app = builder.Build();

// Конвейер обработки запроса
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/todos", (ApplicationContext appContext) => Results.Ok(appContext.Todos));
app.MapPost("/api/todos", (ApplicationContext appContext, CreateTodoDto dto) =>
{
    var newTodo = new Todo() { Title = dto.Title, IsCompleted = dto.IsCompleted};
    return Results.Ok(appContext.Create(newTodo));
});

app.MapControllers();

app.Run();
