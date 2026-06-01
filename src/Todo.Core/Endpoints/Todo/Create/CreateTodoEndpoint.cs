using System.Security.Claims;
using Todo.Core.EndpointSettings;

namespace Todo.Core.Endpoints.Todos.Create;

public sealed class CreateTodoEndpoint : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapPost("/todos", async (
            CreateTodoRequest request,
            CreateTodoHandler handler,
            ClaimsPrincipal user,
            CancellationToken ct) => await handler.HandleAsync(request, user, ct))
            .WithTags("Todos")
            .RequireAuthorization();
    }
}