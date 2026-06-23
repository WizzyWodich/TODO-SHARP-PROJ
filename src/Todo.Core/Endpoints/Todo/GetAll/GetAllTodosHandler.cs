using System.Security.Claims;
using System.Text.Json;
using Todo.Core.Endpoints.Todo.GetAll;
using Todo.Domain.Repositories;


namespace Todo.Core.Endpoints.Todo.GetAll;

public sealed class GetAllTodosHandler
{
    private readonly ITodoRepository _todos;

    public GetAllTodosHandler(ITodoRepository todos)
    {
        _todos = todos;
    }

    public async Task<IResult> HandleAsync(GetAllTodosQuery query, ClaimsPrincipal user, CancellationToken ct)
    {
        var userId = int.Parse(user.FindFirstValue("userId")!);

        var (todosPage, totalCount) = await _todos.GetByUserIdAsync(
            userId, query.Page, query.PageSize, ct);
        return Results.Ok(new
        {
            data = todosPage,
            page = query.Page,
            pageSize = query.PageSize,
            total = totalCount,
            totalPages = (int)Math.Ceiling((double)totalCount / query.PageSize)
        });
    }
}