using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Models;

namespace Todo.Infrastructure.PostgreSQL.Data.Configurations;

public sealed class TodoConfiguration : IEntityTypeConfiguration<TodoModel>
{
    public void Configure(EntityTypeBuilder<TodoModel> builder)
    {
        builder.ToTable("todos");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Title).HasMaxLength(200).IsRequired();
        builder.Property(t => t.Description).HasMaxLength(2000);
        builder.Property(t => t.CreatedAt).IsRequired();
        builder.Property(t => t.UpdatedAt).IsRequired();
        builder.Property(t => t.ConfirmedAt);
        builder.Ignore(t => t.IsCompleted);

        builder.HasOne<UserModel>()
            .WithMany()
            .HasForeignKey(t => t.UserId);
    }
}