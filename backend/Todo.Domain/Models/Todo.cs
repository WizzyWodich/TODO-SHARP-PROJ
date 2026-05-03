namespace Todo.Domain.Models;
public sealed class TodoModel
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public bool IsCompleted { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public DateTime? ConfirmedAt { get; private set; }

    public TodoModel() { }
    
    public static TodoModel Create(Guid userId, string title, string description)
    {
        if (userId == Guid.Empty) 
            throw new ArgumentException("UserId cannot be empty", nameof(userId));
        if (string.IsNullOrWhiteSpace(title)) 
            throw new ArgumentException("Title cannot be empty", nameof(title));
        
        return new TodoModel
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Title = title,
            Description = description,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }
    
    public void Complete()
    {
        if (IsCompleted) throw new InvalidOperationException("Todo is already completed");
        IsCompleted = true;
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
}