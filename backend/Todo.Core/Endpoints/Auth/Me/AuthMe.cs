using Todo.Core.EndpointSettings;

namespace Todo.Core.Endpoints.Auth.Me;

public sealed class AuthMe : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapGet("/auth/me", (HttpContext http) =>
        {
            var user = http.User;

            if (user?.Identity?.IsAuthenticated != true)
                return Results.Unauthorized();

            return Results.Ok(new
            {
                name = user.Identity?.Name
            });

        }).WithTags("Auth");
    }
}