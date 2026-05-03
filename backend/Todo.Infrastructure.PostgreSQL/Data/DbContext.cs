using Microsoft.EntityFrameworkCore;
using Todo.Domain.Models;

namespace Todo.Infrastructure.PostgreSQL.Data;
public sealed class AppDbContext : DbContext
{
    public DbSet<UserModel> Users => Set<UserModel>();
    public DbSet<TodoModel> Todos => Set<TodoModel>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}