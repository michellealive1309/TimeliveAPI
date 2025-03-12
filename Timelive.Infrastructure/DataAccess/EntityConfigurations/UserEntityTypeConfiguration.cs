using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timelive.Domain.Entities;

namespace Timelive.Infrastructure.DataAccess.EntityConfigurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(u => u.Id);

        builder
            .HasIndex(u => u.Email)
            .IsUnique();

        builder
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(320);
        builder
            .Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(100);
        builder
            .Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(255);
    }
}
