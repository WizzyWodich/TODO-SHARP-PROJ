namespace Todo.Core.Endpoints.Todo.GetAll;

public record GetAllTodosQuery(int Page = 1, int PageSize = 20);