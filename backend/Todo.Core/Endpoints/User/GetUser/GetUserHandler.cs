using System.Security.Claims;
using Todo.Domain.Repositories;

namespace Todo.Core.Endpoints.User.GetUser;

public class GetUserHandler
{
    private readonly IUserRepository _userRepository;

    public GetUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IResult> HandleAsync(ClaimsPrincipal user, CancellationToken ct)
    {
        var userId = Guid.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var userDTO = await _userRepository.FindUserByIdAsync(userId, ct);

        if (user is null)
            return Results.NotFound();

        return Results.Ok(userDTO);
    }
}