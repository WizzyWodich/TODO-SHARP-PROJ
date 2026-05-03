using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Todo.Domain.Repositories;

namespace Todo.Core.Endpoints.Auth.Login;

public sealed class LoginHandler
{
    private readonly IUserRepository _users;
    private readonly IConfiguration _config;

    public LoginHandler(IUserRepository users, IConfiguration config)
    {
        _users = users;
        _config = config;
    }

    public async Task<IResult> HandleAsync(LoginRequest request, HttpContext http, CancellationToken ct)
    {
        var user = await _users.FindByUserNameAsync(request.UserName, ct);

        if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            return Results.Unauthorized();

        var token = GenerateJwt(user);

        http.Response.Cookies.Append("access_token", token, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict,
            Expires = DateTimeOffset.UtcNow.AddDays(7)
        });

        return Results.Ok();
    }

    private string GenerateJwt(Todo.Domain.Models.UserModel user)
    {
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_config["Jwt:Secret"]!));

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
        };

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}