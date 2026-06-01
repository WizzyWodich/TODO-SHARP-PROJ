using Todo.Domain.Models;
using Todo.Domain.Repositories;

namespace Todo.Core.Endpoints.Auth.Register;

public sealed class RegisterHandler
{
    private readonly IUserRepository _users;

    public RegisterHandler(IUserRepository users) => _users = users;

    public async Task<IResult> HandleAsync(RegisterRequest request, CancellationToken ct)
    {
        if (await _users.GetForAuthenticationAsync(request.UserName, ct) is not null)
            return Results.Conflict("Username already taken");

        var hash = BCrypt.Net.BCrypt.HashPassword(request.Password, workFactor: 10);
        var user = UserModel.Create(request.UserName, hash, request.Email);
        await _users.AddAsync(user, ct);

        return Results.NoContent();
    }
}