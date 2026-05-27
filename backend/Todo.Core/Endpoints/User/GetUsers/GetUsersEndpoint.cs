using System.Security.Claims;
using Todo.Core.Endpoints.User.GetUser;
using Todo.Core.EndpointSettings;

namespace Todo.Core.Endpoints.User.GetUsers;

public sealed class GetUsersEndpoint : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapGet("/api/users", async (GetUserHandler handler, ClaimsPrincipal user, CancellationToken ct) =>
        {
            return await handler.HandleAsync(user, ct);
        })
        .WithName("GetUsers")
        .WithTags("Users")
        .RequireAuthorization();
    }
}