namespace Todo.Domain.Models;

public sealed class UserModel
{
    private UserModel() { } 
    public int Id { get; private set; }
    public Guid PublicId {get; private set; }
    public string UserName { get; private set; }
    public string PasswordHash { get; private set; }
    public string? Email { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public static UserModel Create(string userName, string passwordHash, string? email)
    {
        if (string.IsNullOrWhiteSpace(userName))
            throw new ArgumentException("Username cannot be empty", nameof(userName));
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("PasswordHash cannot be empty", nameof(passwordHash));

        return new UserModel
        {
            PublicId = Guid.NewGuid(),
            UserName = userName,
            PasswordHash = passwordHash,
            Email = email,
            CreatedAt = DateTime.UtcNow
        };
    }
}