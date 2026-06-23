using System.Security.Claims;
using Todo.Core.EndpointSettings;

namespace Todo.Core.Endpoints.Todo.Complete;

public sealed class CompleteTodoEndpoint : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapPatch("/todos/{id:int}/complete", async (
            int id,
            CompleteTodoHandler handler,
            ClaimsPrincipal user,
            CancellationToken ct) => await handler.HandleAsync(id, user, ct))
            .WithTags("Todos")
            .RequireAuthorization();
    }
}