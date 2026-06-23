using Todo.Domain.Enums;

namespace Todo.Domain.Models;
public sealed class TodoModel
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public TodoPriority Priority { get; private set; }
    public bool IsCompleted => ConfirmedAt.HasValue;
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public DateTime? ConfirmedAt { get; private set; }
    public DateTime? DueAt { get; private set; }

    private TodoModel() { }
    
    public static TodoModel Create(int userId, string title, string description, TodoPriority priority = TodoPriority.Low, DateTime? dueAt = null)
    {
        if (userId <= 0) 
            throw new ArgumentException("UserId cannot be empty", nameof(userId));
        if (string.IsNullOrWhiteSpace(title)) 
            throw new ArgumentException("Title cannot be empty", nameof(title));
        
        return new TodoModel
        {
            UserId = userId,
            Title = title,
            Description = description,
            Priority = priority,
            DueAt = dueAt,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }
    
    public void Complete()
    {
        if (IsCompleted) throw new InvalidOperationException("Todo is already completed");
        ConfirmedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty", nameof(title));
        Title = title;
        UpdatedAt = DateTime.UtcNow;
    }
    public void SetDueDate(DateTime? dueAt)
    {
        DueAt = dueAt;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateDescription(string description)
    {
        Description = description;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdatePriority(TodoPriority priority)
    {
        Priority = priority;
        UpdatedAt = DateTime.UtcNow;
    }
}