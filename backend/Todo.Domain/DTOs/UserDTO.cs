namespace Todo.Domain.DTOs;

public record UserDTO(Guid Id, string UserName, string? Email);