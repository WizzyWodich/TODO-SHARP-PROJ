using Microsoft.EntityFrameworkCore;
using Todo.Domain.DTOs;
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

    public Task<UserModel?> FindByUserNameAsync(string userName, CancellationToken ct)
        => _db.Users.FirstOrDefaultAsync(u => u.UserName == userName, ct);

    public async Task AddAsync(UserModel user, CancellationToken ct)
    {
        await _db.Users.AddAsync(user, ct);
        await _db.SaveChangesAsync(ct);
    }

    public Task UpdateAsync(UserModel user, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid userId, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<UserDTO?> FindUserByIdAsync(Guid userId, CancellationToken ct)
    {
        return _db.Users
            .Where(u => u.Id == userId)
            .Select(u => new UserDTO(u.UserName, u.Email))
            .FirstOrDefaultAsync(ct);
    }
}