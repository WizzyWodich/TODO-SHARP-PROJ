namespace Todo.Core.Extentions;

using Microsoft.AspNetCore.Builder;
using Todo.Core.EndpointSettings;

public static class Applicationextentions
{
    public static WebApplication UseApplicationMiddleware(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors("AllowAll");
        app.UseAuthorization();
        
        // Регистрируем все эндпоинты
        app.MapEndpoints();
        app.MapControllers();

        return app;
    }

    public static async Task RunApplicationAsync(this WebApplication app)
    {
        await app.RunAsync();
    }
}
