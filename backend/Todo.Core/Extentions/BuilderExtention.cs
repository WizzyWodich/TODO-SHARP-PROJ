using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Todo.Core.Endpoints.Auth.Login;
using Todo.Core.Endpoints.Auth.Register;
using Todo.Core.Endpoints.Todos.Complete;
using Todo.Core.Endpoints.Todos.Create;
using Todo.Core.Endpoints.Todos.Delete;
using Todo.Core.Endpoints.Todos.GetAll;
using Todo.Core.EndpointSettings;
using Todo.Domain.Repositories;
using Todo.Infrastructure.PostgreSQL.Data;
using Todo.Infrastructure.PostgreSQL.Repositories;

namespace Todo.Core.Extentions;

public static class BuilderExtention
{
    public static WebApplicationBuilder AddApplicationServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "TODO Sharp API",
                Version = "v1",
                Description = "API для управления задачами",
                Contact = new OpenApiContact
                {
                    Name = "TODO Sharp Team",
                    Email = "support@todosharp.com"
                },
                License = new OpenApiLicense
                {
                    Name = "MIT"
                }
            });

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.ApiKey,
                Name = "Authorization",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header"
            });
        });

        return builder;
    }

    public static WebApplicationBuilder AddDependencyInjection(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<RegisterHandler>();
        builder.Services.AddScoped<LoginHandler>();
        builder.Services.AddScoped<ITodoRepository, TodoRepository>();
        builder.Services.AddScoped<CreateTodoHandler>();
        builder.Services.AddScoped<GetAllTodosHandler>();
        builder.Services.AddScoped<ITodoRepository, TodoRepository>();
        builder.Services.AddScoped<DeleteTodoHandler>();
        builder.Services.AddScoped<CompleteTodoHandler>();
        
        return builder;
    }
    
    public static WebApplicationBuilder AddCorsPolicy(this WebApplicationBuilder builder, string policyName = "AllowAll")
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(policyName, policy =>
            {
                policy.WithOrigins("http://localhost:3000")
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .AllowCredentials();
            });
        });

        return builder;
    }

    public static WebApplicationBuilder AddApplicationLogging(this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();

        if (builder.Environment.IsDevelopment())
        {
            builder.Logging.AddDebug();
        }

        return builder;
    }


    public static WebApplicationBuilder AddDatabase(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
        return builder;
    }

    public static IApplicationBuilder MapEndpoints(this WebApplication app)
    {
        var endpointTypes = typeof(Program).Assembly.GetTypes()
            .Where(t => typeof(IEndpoint).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

        foreach (var endpointType in endpointTypes)
        {
            var endpoint = Activator.CreateInstance(endpointType) as IEndpoint;
            endpoint?.MapEndpoint(app);
        }

        return app;
    }

    public static WebApplicationBuilder AddJwt(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = ctx =>
                    {
                        ctx.Token = ctx.Request.Cookies["access_token"];
                        return Task.CompletedTask;
                    }
                };
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]!))
                };
            });

        builder.Services.AddAuthorization();
        return builder;
    }
}