using Todo.Domain.Repositories;

namespace Todo.Core.Endpoints.User.GetUsers;

public class GetUsersHandler
{
    private readonly IUserRepository _userRepository;

    public GetUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<IResult> HandleAsync(CancellationToken ct)
    {
        var users = await _userRepository.GetAllUsersAsync(ct);
        return Results.Ok(users);
    }
}