using System.Security.Claims;
using Todo.Domain.Repositories;

namespace Todo.Core.Endpoints.Todo.Delete;

public sealed class DeleteTodoHandler
{
    private readonly ITodoRepository _todos;

    public DeleteTodoHandler(ITodoRepository todos) => _todos = todos;

    public async Task<IResult> HandleAsync(int id, ClaimsPrincipal user, CancellationToken ct)
    {
        var userId = int.Parse(user.FindFirstValue("userId")!);
        var todo = await _todos.GetByIdAsync(id, ct);

        if (todo is null)
            return Results.NotFound();

        if (todo.UserId != userId)
            return Results.Forbid();

        await _todos.DeleteAsync(todo, ct);
        return Results.NoContent();
    }
}