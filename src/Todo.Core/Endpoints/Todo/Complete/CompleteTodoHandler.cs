using System.Security.Claims;
using Todo.Domain.Repositories;

namespace Todo.Core.Endpoints.Todo.Complete;

public sealed class CompleteTodoHandler
{
    private readonly ITodoRepository _todos;

    public CompleteTodoHandler(ITodoRepository todos) => _todos = todos;

    public async Task<IResult> HandleAsync(int id, ClaimsPrincipal user, CancellationToken ct)
    {
        var userId = int.Parse(user.FindFirstValue("userId")!);
        var todo = await _todos.GetByIdAsync(id, ct);

        if (todo is null)
            return Results.NotFound();

        if (todo.UserId != userId)
            return Results.Forbid();

       try
        {
            todo.Complete();
            await _todos.UpdateAsync(todo, ct);
            return Results.NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return Results.BadRequest(new { message = ex.Message });
        }
    }
}