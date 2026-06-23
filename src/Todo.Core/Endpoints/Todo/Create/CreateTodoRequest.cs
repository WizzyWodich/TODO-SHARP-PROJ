using Todo.Domain.Enums;

namespace Todo.Core.Endpoints.Todo.Create;

public record CreateTodoRequest(
    string Title,
    string Description,
    TodoPriority Priority = TodoPriority.Low,
    DateTime? DueAt = null);