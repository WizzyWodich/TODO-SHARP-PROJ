using Microsoft.Extensions.Caching.Distributed;
using System.Security.Claims;
using System.Text.Json;
using Todo.Core.Endpoints.Todos.GetAll;
using Todo.Domain.Repositories;

public sealed class GetAllTodosHandler
{
    private readonly ITodoRepository _todos;
    private readonly IDistributedCache _cache;

    public GetAllTodosHandler(ITodoRepository todos, IDistributedCache cache)
    {
        _todos = todos;
        _cache = cache;
    }

    public async Task<IResult> HandleAsync(GetAllTodosQuery query, ClaimsPrincipal user, CancellationToken ct)
    {
        var userId = int.Parse(user.FindFirstValue("userId")!);

        if (query.Page == 1)
        {
            var cacheKey = $"todos:{userId}:page1:{query.PageSize}";
            var cached = await _cache.GetStringAsync(cacheKey, ct);

            if (cached != null)
                return Results.Ok(JsonSerializer.Deserialize<object>(cached));

            var (todos, total) = await _todos.GetByUserIdAsync(userId, query.Page, query.PageSize, ct);
            var response = new
            {
                data = todos,
                page = query.Page,
                pageSize = query.PageSize,
                total,
                totalPages = (int)Math.Ceiling((double)total / query.PageSize)
            };

            await _cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(response),
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                }, ct);

            return Results.Ok(response);
        }

        var (todosPage, totalCount) = await _todos.GetByUserIdAsync(userId, query.Page, query.PageSize, ct);
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