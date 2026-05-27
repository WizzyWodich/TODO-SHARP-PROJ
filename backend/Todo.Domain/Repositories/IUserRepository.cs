using Todo.Domain.DTOs;
using Todo.Domain.Models;

namespace Todo.Domain.Repositories;

public interface IUserRepository
{
    Task<UserModel?> GetForAuthenticationAsync(string userName, CancellationToken ct);

    Task<bool> ExistsAsync(string userName, CancellationToken ct);
    Task<UserDTO?> FindUserByIdAsync(Guid userId, CancellationToken ct);
    // TODO: lazy loading for tasks and other related entities
    Task<IEnumerable<UserDTO>> GetAllUsersAsync(CancellationToken ct);
    Task AddAsync(UserModel user, CancellationToken ct);
    Task UpdateAsync(UserModel user, CancellationToken ct);
    Task DeleteAsync(Guid userId, CancellationToken ct);
}