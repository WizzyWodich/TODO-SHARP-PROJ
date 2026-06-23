using System.Security.Claims;
using Todo.Domain.Models;
using Todo.Domain.Enums;
using Todo.Domain.Repositories;
using Todo.Domain;

namespace Todo.Core.Endpoints.Todo.Update;

public sealed class UpdateTodoHandler(ITodoRepository repository)
{
    public async Task<IResult> HandleAsync(
        int id,
        UpdateTodoRequest request,
        ClaimsPrincipal user,
        CancellationToken ct)
    {
        var userId = int.Parse(user.FindFirstValue("userId")!);
        var todo = await repository.GetByIdAsync(id, ct);

        if (todo is null)
            return Results.NotFound();

        if (todo.UserId != userId)
            return Results.Forbid();

        if (todo.IsCompleted)
            return Results.BadRequest("Cannot update completed todo");

        if (!string.IsNullOrWhiteSpace(request.Title))
            todo.UpdateTitle(request.Title);

        if (!string.IsNullOrWhiteSpace(request.Description))
            todo.UpdateDescription(request.Description); 

        if (!string.IsNullOrWhiteSpace(request.Priority) && 
            Enum.TryParse<TodoPriority>(request.Priority, out var priority))
            todo.UpdatePriority(priority);  

        if (request.DueAt.HasValue)
            todo.SetDueDate(request.DueAt);

        await repository.UpdateAsync(todo, ct);
        return Results.NoContent();
    }
}