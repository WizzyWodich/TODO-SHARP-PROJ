using System.Security.Claims;
using Todo.Domain.Models;
using Todo.Domain.Repositories;

namespace Todo.Core.Endpoints.Statistic;

public class GetStatsHandler(IStatisticRepository repository)
{
    public async Task<StatsModel> HandleAsync(
        ClaimsPrincipal user,
        CancellationToken ct)
    {
        var userId = int.Parse(user.FindFirstValue("userId")!);
        return await repository.GetStatsByUserIdAsync(userId, ct);
    }
}