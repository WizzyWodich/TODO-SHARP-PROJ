using System.Security.Claims;
using Todo.Core.EndpointSettings;

namespace Todo.Core.Endpoints.Todos.GetAll;

public sealed class GetAllTodosEndpoint : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapGet("/todos", async (
            GetAllTodosHandler handler,
            ClaimsPrincipal user,
            CancellationToken ct) => await handler.HandleAsync(user, ct))
            .WithTags("Todos")
            .RequireAuthorization();
    }
}