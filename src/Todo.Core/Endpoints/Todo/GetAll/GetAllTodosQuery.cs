namespace Todo.Core.Endpoints.Todos.GetAll;

public record GetAllTodosQuery(int Page = 1, int PageSize = 20);