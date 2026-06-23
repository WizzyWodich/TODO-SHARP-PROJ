using Microsoft.EntityFrameworkCore;
using Todo.Domain.Models;
using Todo.Domain.Repositories;
using Todo.Infrastructure.PostgreSQL.Data;

namespace Todo.Infrastructure.PostgreSQL.Repositories;

public class StatisticRepository(AppDbContext dbContext) : IStatisticRepository
{
    public async Task<StatsModel> GetStatsByUserIdAsync(int userId, CancellationToken ct)
    {
        var todos = await dbContext.Todos
            .AsNoTracking()
            .Where(t => t.UserId == userId)
            .ToListAsync(ct);

        var total = todos.Count;
        var completed = todos.Count(t => t.IsCompleted);
        var now = DateTime.UtcNow;
        var todayDate = now.Date;
        
        return new StatsModel
        {
            TotalTodos = total,
            CompletedTodos = completed,
            PendingTodos = total - completed,
            OverdueCount = todos.Count(t => 
                !t.IsCompleted && t.DueAt.HasValue && t.DueAt.Value < now),
            DueTodayCount = todos.Count(t => 
                !t.IsCompleted && t.DueAt.HasValue && t.DueAt.Value.Date == todayDate),
            DueThisWeekCount = todos.Count(t => 
                !t.IsCompleted && t.DueAt.HasValue && 
                t.DueAt.Value >= now && t.DueAt.Value <= now.AddDays(7)),
            ByPriority = todos
                .Where(t => !t.IsCompleted && t.DueAt.HasValue)
                .GroupBy(t => t.Priority.ToString())
                .ToDictionary(g => g.Key, g => g.Count()),
            CompletionRate = total == 0 ? 0 : (completed / (double)total) * 100
        };
    }
}