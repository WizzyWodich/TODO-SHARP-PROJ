using System.Security.Claims;
using Todo.Core.EndpointSettings;

namespace Todo.Core.Endpoints.User.PatchPassword;

public sealed class ChangePasswordEndpoint : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapPatch("/users/password-change", async (
            ChangePasswordRequest request,
            ChangePasswordHandler handler,
            ClaimsPrincipal user,
            CancellationToken ct) => await handler.HandleAsync(request, user, ct))
            .WithTags("Users")
            .RequireAuthorization();
    }
}