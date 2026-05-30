using System.Text.Json.Serialization;

namespace Todo.Core.Endpoints.User.GetUser;

public record GetUserResponse(
    Guid Id,
    [property: JsonPropertyName("username")] string UserName,
    string? Email
);