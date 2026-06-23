using System.Security.Claims;
using Todo.Domain.Repositories;

namespace Todo.Core.Endpoints.Todo.Delete;

public sealed class DeleteTodoAllHandler
{
    private readonly ITodoRepository _repository;
    
    public DeleteTodoAllHandler(ITodoRepository repository) => _repository = repository;

    public async Task<IResult> HandleAsync(ClaimsPrincipal user, CancellationToken ct)
    {
        var userId = int.Parse(user.FindFirstValue("userId")!);
        await _repository.DeleteAllByUserIdAsync(userId, ct);
        return Results.NoContent();
    }
}