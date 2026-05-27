using Microsoft.EntityFrameworkCore;
using Todo.Domain.Models;
using Todo.Domain.Repositories;
using Todo.Infrastructure.PostgreSQL.Data;

namespace Todo.Infrastructure.PostgreSQL.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly AppDbContext _db;

    public UserRepository(AppDbContext db) => _db = db;

    public Task<bool> ExistsAsync(string userName, CancellationToken ct)
        => _db.Users.AnyAsync(u => u.UserName == userName, ct);

    public Task<UserModel?> GetForAuthenticationAsync(string userName, CancellationToken ct)
        => _db.Users.FirstOrDefaultAsync(u => u.UserName == userName, ct);

    public async Task AddAsync(UserModel user, CancellationToken ct)
    {
        await _db.Users.AddAsync(user, ct);
        await _db.SaveChangesAsync(ct);
    }

    public Task UpdatePasswordAsync(Guid userId, string newPasswordHash, CancellationToken ct)
    {
        return _db.Users
            .Where(u => u.Id == userId)
            .ExecuteUpdateAsync(s => s.SetProperty(u => u.PasswordHash, newPasswordHash), ct);
    }

    public Task UpdateEmailAsync(Guid userId, string newEmail, CancellationToken ct)
    {
        return _db.Users
            .Where(u => u.Id == userId)
            .ExecuteUpdateAsync(s => s.SetProperty(u => u.Email, newEmail), ct);
    }

    public Task DeleteAsync(Guid userId, CancellationToken ct)
    {
        return _db.Users
            .Where(u => u.Id == userId)
            .ExecuteDeleteAsync(ct);
    }

    public Task<UserModel?> FindUserByIdAsync(Guid userId, CancellationToken ct)
    {
        return _db.Users
            .Where(u => u.Id == userId)
            .FirstOrDefaultAsync(ct);
    }

    public async Task<IEnumerable<UserModel>> GetAllUsersAsync(CancellationToken ct)
    {
        return await _db.Users
            .AsNoTracking()
            .OrderBy(u => u.UserName)
            .ToListAsync(ct);
    }
}