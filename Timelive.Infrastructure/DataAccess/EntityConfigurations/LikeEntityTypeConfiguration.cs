using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timelive.Domain.Entities;

namespace Timelive.Infrastructure.DataAccess.EntityConfigurations;

public class LikeEntityTypeConfiguration : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder.ToTable("likes");
        builder.HasKey(l => l.Id);

        builder
            .Property(l => l.StoryId)
            .IsRequired();
        builder
            .Property(l => l.ProfileId)
            .IsRequired();

        builder
            .HasOne(l => l.Profile)
            .WithMany()
            .HasForeignKey(l => l.ProfileId)
            .IsRequired();
        builder
            .HasOne(l => l.Story)
            .WithMany()
            .HasForeignKey(l => l.StoryId)
            .IsRequired();
    }
}
