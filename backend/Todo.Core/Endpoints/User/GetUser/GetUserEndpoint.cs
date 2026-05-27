using System.Security.Claims;
using Todo.Core.EndpointSettings;

namespace Todo.Core.Endpoints.User.GetUser;

public class GetUserEndpoint : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapGet("/users/{id}", async (GetUserHandler handler, ClaimsPrincipal user, CancellationToken ct) =>
        {
            return await handler.HandleAsync(user, ct);
        })
        .WithName("GetUser")
        .WithTags("Users")
        .RequireAuthorization();
    }
}