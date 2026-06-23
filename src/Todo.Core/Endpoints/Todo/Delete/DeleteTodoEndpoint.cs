using System.Security.Claims;
using Todo.Core.EndpointSettings;

namespace Todo.Core.Endpoints.Todo.Delete;

public sealed class DeleteTodoEndpoint : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapDelete("/todos/{id:int}", async (
            int id,
            DeleteTodoHandler handler,
            ClaimsPrincipal user,
            CancellationToken ct) => await handler.HandleAsync(id, user, ct))
            .WithTags("Todos")
            .RequireAuthorization();
    }
}