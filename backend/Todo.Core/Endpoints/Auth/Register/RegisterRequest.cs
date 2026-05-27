namespace Todo.Core.Endpoints.Auth.Register;

public record RegisterRequest(string UserName, string Password, string? Email);