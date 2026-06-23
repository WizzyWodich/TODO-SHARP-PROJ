using System.Security.Claims;
using Todo.Core.EndpointSettings;

namespace Todo.Core.Endpoints.Todo.Update;

public sealed class UpdateTodoEndpoint : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapPatch("/todos/{id:int}", async (
            int id,
            UpdateTodoRequest request,
            UpdateTodoHandler handler,
            ClaimsPrincipal user,
            CancellationToken ct) => await handler.HandleAsync(id, request, user, ct))
            .WithTags("Todos")
            .RequireAuthorization();
    }
}