using Todo.Core.EndpointSettings;

namespace Todo.Core.Endpoints.Auth.Logout;

public sealed class LogoutEndpoint : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapPost("/auth/logout", (HttpContext http) =>
        {
            http.Response.Cookies.Delete("access_token");
            return Results.Ok();
        }).WithTags("Auth");
    }
}