using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Todo.Domain.Repositories;

namespace Todo.Core.Endpoints.User.PatchPassword;

public class ChangePasswordHandler
{
    private readonly IUserRepository _userRepository;

    public ChangePasswordHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IResult> HandleAsync(ChangePasswordRequest request, ClaimsPrincipal user, CancellationToken ct)
    {
        var userId = Guid.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier)!);

        if (userId == Guid.Empty)
            return Results.Forbid();
        
        var currentUser = await _userRepository.FindUserByIdAsync(userId, ct);
        if (currentUser is null)
            return Results.NotFound();

        if (!BCrypt.Net.BCrypt.Verify(request.CurrentPassword, currentUser.PasswordHash))
            return Results.BadRequest(new { error = "Current password is incorrect." });
        
        if (BCrypt.Net.BCrypt.Verify(request.NewPassword, currentUser.PasswordHash))
            return Results.BadRequest(new { error = "New password must be different from current password." });
        
        var newPasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
        await _userRepository.UpdatePasswordAsync(userId, newPasswordHash, ct);
        

        return Results.Ok(new { Message = "Password changed successfully." });
    }
}