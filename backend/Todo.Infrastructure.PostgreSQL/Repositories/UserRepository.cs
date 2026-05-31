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
        => _db.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.UserName == userName, ct);

    public Task<UserModel?> GetByIdAsync(int userId, CancellationToken ct)
        =>   _db.Users
            .AsNoTracking()
            .Where(u => u.Id == userId)
            .FirstOrDefaultAsync(ct);

     public async Task<IEnumerable<UserModel>> GetAllAsync(CancellationToken ct)
         => await _db.Users
            .AsNoTracking()
            .OrderBy(u => u.UserName)
            .ToListAsync(ct);


    public Task UpdatePasswordAsync(int userId, string newPasswordHash, CancellationToken ct)
        => _db.Users
            .Where(u => u.Id == userId)
            .ExecuteUpdateAsync(s => s.SetProperty(u => u.PasswordHash, newPasswordHash), ct);

    public Task UpdateEmailAsync(int userId, string newEmail, CancellationToken ct)
        => _db.Users
            .Where(u => u.Id == userId)
            .ExecuteUpdateAsync(s => s.SetProperty(u => u.Email, newEmail), ct);

    public Task DeleteAsync(int userId, CancellationToken ct)
        => _db.Users
            .Where(u => u.Id == userId)
            .ExecuteDeleteAsync(ct);

    public async Task<int> AddAsync(UserModel user, CancellationToken ct)
    {
        await _db.Users.AddAsync(user, ct);
        await _db.SaveChangesAsync(ct);
        return user.Id;
    }

    public Task<UserModel?> GetByPublicIdAsync(Guid publicId, CancellationToken ct)
        => _db.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.PublicId == publicId, ct);
}