using Microsoft.EntityFrameworkCore;
using Todo.Domain.Models;
using Todo.Domain.Repositories;
using Todo.Infrastructure.PostgreSQL.Data;

namespace Todo.Infrastructure.PostgreSQL.Repositories;

public sealed class TodoRepository : ITodoRepository
{
    private readonly AppDbContext _db;

    public TodoRepository(AppDbContext db) => _db = db;

    public async Task AddAsync(TodoModel todo, CancellationToken ct)
    {
        await _db.Todos.AddAsync(todo, ct);
        await _db.SaveChangesAsync(ct);
    }

    public async Task<(IReadOnlyList<TodoModel> Items, int Total)> GetByUserIdAsync(
        Guid userId, int page, int pageSize, CancellationToken ct)
    {
        var query = _db.Todos
            .Where(t => t.UserId == userId)
            .OrderByDescending(t => t.CreatedAt);

        var total = await query.CountAsync(ct);
        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync(ct);

        return (items, total);
    }
    
    public async Task<TodoModel?> GetByIdAsync(Guid id, CancellationToken ct)
        => await _db.Todos.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id, ct);

    public async Task UpdateAsync(TodoModel todo, CancellationToken ct)
    {
        _db.Todos.Update(todo);
        await _db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(TodoModel todo, CancellationToken ct)
    {
        _db.Todos.Remove(todo);
        await _db.SaveChangesAsync(ct);
    }
}