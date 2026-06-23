using System.Security.Claims;
using Todo.Core.EndpointSettings;

namespace Todo.Core.Endpoints.Todo.Delete;

public sealed class DeleteTodoAllEndpoint : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapDelete("/todos/all", async (
            DeleteTodoAllHandler handler,
            ClaimsPrincipal user,
            CancellationToken ct) => await handler.HandleAsync(user, ct))
            .WithTags("Todos")
            .RequireAuthorization();
    }
}