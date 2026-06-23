namespace Todo.Domain.Models;

public class StatsModel
{
    public int TotalTodos { get; set; }
    public int CompletedTodos { get; set; }
    public int PendingTodos { get; set; }
    public int OverdueCount { get; set; }
    public int DueTodayCount { get; set; }
    public int DueThisWeekCount { get; set; }
    public Dictionary<string, int> ByPriority { get; set; } = new();
    public double CompletionRate { get; set; }
}