using Microsoft.AspNetCore.Builder;

namespace Todo.Core.EndpointSettings;

public interface IEndpoint
{
    void MapEndpoint(WebApplication app);
}
