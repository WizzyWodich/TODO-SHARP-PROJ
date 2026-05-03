using System.Security.Claims;
using Todo.Domain.Models;
using Todo.Domain.Repositories;

namespace Todo.Core.Endpoints.Todos.GetAll;

public sealed class GetAllTodosHandler
{
    private readonly ITodoRepository _todos;

    public GetAllTodosHandler(ITodoRepository todos) => _todos = todos;

    public async Task<IResult> HandleAsync(ClaimsPrincipal user, CancellationToken ct)
    {
        var userId = Guid.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var todos = await _todos.GetByUserIdAsync(userId, ct);
        return Results.Ok(todos);
    }
}