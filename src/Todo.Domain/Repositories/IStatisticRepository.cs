using Todo.Domain.Models;

namespace Todo.Domain.Repositories;

public interface IStatisticRepository
{
    Task<StatsModel> GetStatsByUserIdAsync(int userId, CancellationToken ct);
}