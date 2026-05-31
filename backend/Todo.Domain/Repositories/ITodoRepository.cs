using Todo.Domain.Models;

namespace Todo.Domain.Repositories;

public interface ITodoRepository
{
    Task AddAsync(TodoModel todo, CancellationToken ct);
    Task<(IReadOnlyList<TodoModel> Items, int Total)> GetByUserIdAsync(
        int userId, int page, int pageSize, CancellationToken ct);
    Task<TodoModel?> GetByIdAsync(int id, CancellationToken ct);
    Task UpdateAsync(TodoModel todo, CancellationToken ct);
    Task DeleteAsync(TodoModel todo, CancellationToken ct);
}