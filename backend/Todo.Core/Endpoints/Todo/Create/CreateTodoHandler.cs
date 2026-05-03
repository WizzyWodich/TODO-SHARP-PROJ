using System.Security.Claims;
using Todo.Domain.Models;
using Todo.Domain.Repositories;

namespace Todo.Core.Endpoints.Todos.Create;

public sealed class CreateTodoHandler
{
    private readonly ITodoRepository _todos;

    public CreateTodoHandler(ITodoRepository todos) => _todos = todos;

    public async Task<IResult> HandleAsync(
        CreateTodoRequest request,
        ClaimsPrincipal user,
        CancellationToken ct)
    {
        var userId = Guid.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier)!);

        var todo = TodoModel.Create(
            userId,
            request.Title,
            request.Description,
            request.Priority,
            request.DueAt);

        await _todos.AddAsync(todo, ct);
        return Results.Ok();
    }
}