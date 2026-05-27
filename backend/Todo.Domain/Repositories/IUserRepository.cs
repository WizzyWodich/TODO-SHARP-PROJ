using Todo.Domain.Models;

namespace Todo.Domain.Repositories;

public interface IUserRepository
{
    // Queries
    Task<UserModel?> GetForAuthenticationAsync(string userName, CancellationToken ct);
    Task<UserModel?> GetByIdAsync(Guid userId, CancellationToken ct);
    Task<IEnumerable<UserModel>> GetAllAsync(CancellationToken ct);
    
    // Commands
    Task<Guid> AddAsync(UserModel user, CancellationToken ct);
    Task UpdatePasswordAsync(Guid userId, string newPasswordHash, CancellationToken ct);
    Task UpdateEmailAsync(Guid userId, string newEmail, CancellationToken ct);
    Task DeleteAsync(Guid userId, CancellationToken ct);
}