using Todo.Core.Extentions;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddApplicationServices()
    .AddCorsPolicy("AllowAll")
    .AddApplicationLogging();

var app = builder.Build();

app.UseApplicationMiddleware();
await app.RunApplicationAsync();
