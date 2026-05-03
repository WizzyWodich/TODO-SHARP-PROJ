using Todo.Domain;

namespace Todo.Core.Endpoints.Todos.Create;

public record CreateTodoRequest(
    string Title,
    string Description,
    TodoPriority Priority = TodoPriority.Low,
    DateTime? DueAt = null);