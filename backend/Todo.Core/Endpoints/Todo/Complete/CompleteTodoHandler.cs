using System.Security.Claims;
using Todo.Domain.Repositories;

namespace Todo.Core.Endpoints.Todos.Complete;

public sealed class CompleteTodoHandler
{
    private readonly ITodoRepository _todos;

    public CompleteTodoHandler(ITodoRepository todos) => _todos = todos;

    public async Task<IResult> HandleAsync(Guid id, ClaimsPrincipal user, CancellationToken ct)
    {
        var userId = Guid.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var todo = await _todos.GetByIdAsync(id, ct);

        if (todo is null)
            return Results.NotFound();

        if (todo.UserId != userId)
            return Results.Forbid();

        todo.Complete();
        await _todos.UpdateAsync(todo, ct);
        return Results.Ok();
    }
}