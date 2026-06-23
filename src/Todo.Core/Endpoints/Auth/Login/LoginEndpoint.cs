using Todo.Core.EndpointSettings;

namespace Todo.Core.Endpoints.Auth.Login;

public sealed class LoginEndpoint : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapPost("/auth/login", async (
            LoginRequest request,
            LoginHandler handler,
            HttpContext http,
            CancellationToken ct) => await handler.HandleAsync(request, http, ct))
            .WithTags("Auth");
    }
}