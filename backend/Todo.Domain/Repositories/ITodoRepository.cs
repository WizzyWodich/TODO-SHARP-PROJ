using Todo.Domain.Models;

namespace Todo.Domain.Repositories;

public interface ITodoRepository
{
    Task AddAsync(TodoModel todo, CancellationToken ct);
    Task<IReadOnlyList<TodoModel>> GetByUserIdAsync(Guid userId, CancellationToken ct);
    Task<TodoModel?> GetByIdAsync(Guid id, CancellationToken ct);
    Task UpdateAsync(TodoModel todo, CancellationToken ct);
    Task DeleteAsync(TodoModel todo, CancellationToken ct);
}