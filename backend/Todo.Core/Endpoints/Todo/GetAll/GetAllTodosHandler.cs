using System.Security.Claims;
using Todo.Domain.Models;
using Todo.Domain.Repositories;

namespace Todo.Core.Endpoints.Todos.GetAll;

public sealed class GetAllTodosHandler
{
    private readonly ITodoRepository _todos;

    public GetAllTodosHandler(ITodoRepository todos) => _todos = todos;

    public async Task<IResult> HandleAsync(GetAllTodosQuery query, ClaimsPrincipal user, CancellationToken ct)
    {
        var userId = int.Parse(user.FindFirstValue("userId")!);
        var (todos, total) = await _todos.GetByUserIdAsync(userId, query.Page, query.PageSize, ct);

        return Results.Ok(new
        {
            data = todos,
            page = query.Page,
            pageSize = query.PageSize,
            total,
            totalPages = (int)Math.Ceiling((double)total / query.PageSize)
        });
    }
}