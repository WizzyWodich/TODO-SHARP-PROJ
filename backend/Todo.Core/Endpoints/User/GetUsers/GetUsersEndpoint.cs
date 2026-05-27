using System.Security.Claims;
using Todo.Core.Endpoints.User.GetUser;
using Todo.Core.EndpointSettings;

namespace Todo.Core.Endpoints.User.GetUsers;

public sealed class GetUsersEndpoint : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapGet("/users", async (GetUsersHandler handler, CancellationToken ct) =>
        {
            return await handler.HandleAsync(ct);
        })
        .WithName("GetUsers")
        .WithTags("Users")
        .RequireAuthorization();
    }
}