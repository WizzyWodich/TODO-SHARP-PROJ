public sealed class User
{
    public Guid Id { get; private set; }
    public string UserName { get; private set; }
    public string PasswordHash { get; private set; }
    public string? Email { get; private set; }

    public User(string userName, string passwordHash, string? email)
    {
        Id = Guid.NewGuid();
        UserName = userName;
        PasswordHash = passwordHash;
        Email = email;
    }
}

public sealed class Todo
{
    
}