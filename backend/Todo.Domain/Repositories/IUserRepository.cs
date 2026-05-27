using Todo.Domain.DTOs;
using Todo.Domain.Models;

namespace Todo.Domain.Repositories;

public interface IUserRepository
{
    Task<bool> ExistsAsync(string userName, CancellationToken ct);
    Task<UserModel?> FindByUserNameAsync(string userName, CancellationToken ct);
    Task<UserDTO?> FindUserByIdAsync(Guid userId, CancellationToken ct);
    Task AddAsync(UserModel user, CancellationToken ct);
    Task UpdateAsync(UserModel user, CancellationToken ct);
    Task DeleteAsync(Guid userId, CancellationToken ct);
}