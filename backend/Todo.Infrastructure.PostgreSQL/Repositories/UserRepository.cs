using Microsoft.EntityFrameworkCore;
using Todo.Domain.Models;
using Todo.Domain.Repositories;
using Todo.Infrastructure.PostgreSQL.Data;

namespace Todo.Infrastructure.PostgreSQL.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly AppDbContext _db;

    public UserRepository(AppDbContext db) => _db = db;

    public Task<UserModel?> GetForAuthenticationAsync(string userName, CancellationToken ct)
        => _db.Users.FirstOrDefaultAsync(u => u.UserName == userName, ct);

    public Task<UserModel?> GetByIdAsync(Guid userId, CancellationToken ct)
        =>   _db.Users
            .Where(u => u.Id == userId)
            .FirstOrDefaultAsync(ct);

     public async Task<IEnumerable<UserModel>> GetAllAsync(CancellationToken ct)
         => await _db.Users
            .AsNoTracking()
            .OrderBy(u => u.UserName)
            .ToListAsync(ct);


    public Task UpdatePasswordAsync(Guid userId, string newPasswordHash, CancellationToken ct)
        => _db.Users
            .Where(u => u.Id == userId)
            .ExecuteUpdateAsync(s => s.SetProperty(u => u.PasswordHash, newPasswordHash), ct);

    public Task UpdateEmailAsync(Guid userId, string newEmail, CancellationToken ct)
        => _db.Users
            .Where(u => u.Id == userId)
            .ExecuteUpdateAsync(s => s.SetProperty(u => u.Email, newEmail), ct);

    public Task DeleteAsync(Guid userId, CancellationToken ct)
        => _db.Users
            .Where(u => u.Id == userId)
            .ExecuteDeleteAsync(ct);

    public async Task<Guid> AddAsync(UserModel user, CancellationToken ct)
    {
        await _db.Users.AddAsync(user, ct);
        await _db.SaveChangesAsync(ct);
        return user.Id;
    }

}