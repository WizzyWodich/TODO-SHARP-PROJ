using Todo.Domain.Models;

namespace Todo.Domain.Repositories;

public interface ITodoRepository
{
    Task AddAsync(TodoModel todo, CancellationToken ct);
    Task<IReadOnlyList<TodoModel>> GetByUserIdAsync(Guid userId, CancellationToken ct);
}