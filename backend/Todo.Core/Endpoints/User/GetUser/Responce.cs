namespace Todo.Core.Endpoints.User.GetUser;

public record GetUserResponse(Guid Id, string UserName, string? Email);