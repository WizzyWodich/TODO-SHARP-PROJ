namespace Todo.Core.Endpoints.Todo.Update;

public sealed class UpdateTodoRequest
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Priority { get; set; }
    public DateTime? DueAt { get; set; }
}