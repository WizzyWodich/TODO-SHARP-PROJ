using Todo.Domain.Models;

namespace Todo.Domain.Repositories;

public interface IUserRepository
{
    Task<UserModel?> GetForAuthenticationAsync(string userName, CancellationToken ct);
    Task<UserModel?> GetByEmailAsync(string email, CancellationToken ct); 
    Task<UserModel?> GetByIdAsync(int id, CancellationToken ct);
    Task<UserModel?> GetByPublicIdAsync(Guid publicId, CancellationToken ct);
    Task<IEnumerable<UserModel>> GetAllAsync(CancellationToken ct);

    Task<int> AddAsync(UserModel user, CancellationToken ct);
    Task UpdatePasswordAsync(int id, string newPasswordHash, CancellationToken ct);
    Task UpdateEmailAsync(int id, string newEmail, CancellationToken ct);
    Task DeleteAsync(int id, CancellationToken ct);
}