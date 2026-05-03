using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Todo.Core.EndpointSettings;
using Todo.Domain.Models;
using Todo.Infrastructure.PostgreSQL.Data;

namespace Todo.Core.Endpoints.Auth;

public sealed class AuthEndpoints : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        var group = app.MapGroup("/auth").WithTags("Auth");
        group.MapPost("/register", Register);
        group.MapPost("/login", Login);
    }

    private static async Task<IResult> Register(
        RegisterRequest request,
        AppDbContext db,
        CancellationToken ct)
    {
        var exists = await db.Users
            .AnyAsync(u => u.UserName == request.UserName, ct);

        if (exists)
            return Results.Conflict("Username already taken");

        var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);
        var user = UserModel.Create(request.UserName, hash, request.Email);

        db.Users.Add(user);
        await db.SaveChangesAsync(ct);

        return Results.Ok();
    }

    private static async Task<IResult> Login(
        LoginRequest request,
        AppDbContext db,
        IConfiguration config,
        CancellationToken ct)
    {
        var user = await db.Users
            .FirstOrDefaultAsync(u => u.UserName == request.UserName, ct);

        if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            return Results.Unauthorized();

        var token = GenerateJwt(user, config);
        return Results.Ok(new AuthResponse(token));
    }

    private static string GenerateJwt(UserModel user, IConfiguration config)
    {
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(config["Jwt:Secret"]!));

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
        };

        var token = new JwtSecurityToken(
            issuer: config["Jwt:Issuer"],
            audience: config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

public record RegisterRequest(string UserName, string Password, string? Email);
public record LoginRequest(string UserName, string Password);
public record AuthResponse(string AccessToken);