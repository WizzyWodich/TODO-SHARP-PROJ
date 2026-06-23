using System.Security.Claims;
using Todo.Core.EndpointSettings;

namespace Todo.Core.Endpoints.Statistic;

public sealed class GetStatsEndpoint : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapGet("/stats", async (
                GetStatsHandler handler,
                ClaimsPrincipal user,
                CancellationToken ct) => await handler.HandleAsync(user, ct))
            .WithTags("Statistics")
            .RequireAuthorization();
    }
}