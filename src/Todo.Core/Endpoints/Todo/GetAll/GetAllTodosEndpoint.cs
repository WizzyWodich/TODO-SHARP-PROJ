using System.Security.Claims;
using Todo.Core.EndpointSettings;

namespace Todo.Core.Endpoints.Todo.GetAll;

public sealed class GetAllTodosEndpoint : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapGet("/todos", async (
            [AsParameters] GetAllTodosQuery query,
            GetAllTodosHandler handler,
            ClaimsPrincipal user,
            CancellationToken ct) => await handler.HandleAsync(query, user, ct))
            .WithTags("Todos")
            .RequireAuthorization();
    }
}