using System.Text.Json.Serialization;

namespace Todo.Core.Endpoints.User.GetUsers;

public record GetUsersResponse(    
    Guid Id,
    [property: JsonPropertyName("username")] string UserName,
    string? Email
);