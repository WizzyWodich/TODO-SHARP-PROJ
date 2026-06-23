using Todo.Core.EndpointSettings;

namespace Todo.Core.Endpoints.Auth.Register;

public sealed class RegisterEndpoint : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapPost("/auth/register", async (
            RegisterRequest request,
            RegisterHandler handler,
            CancellationToken ct) => await handler.HandleAsync(request, ct))
            .WithTags("Auth");
    }
}