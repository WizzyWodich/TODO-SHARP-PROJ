namespace Todo.Core.Endpoints.User.GetUsers;

public record GetUsersResponse(Guid Id, string UserName, string? Email);