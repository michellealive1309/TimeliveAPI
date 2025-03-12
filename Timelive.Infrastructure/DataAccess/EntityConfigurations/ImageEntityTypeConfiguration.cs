using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timelive.Domain.Entities;

namespace Timelive.Infrastructure.DataAccess.EntityConfigurations;

public class ImageEntityTypeConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.ToTable("images");
        builder.HasKey(i => i.Id);

        builder
            .HasOne<Group>()
            .WithOne(g => g.Avatar)
            .HasForeignKey<Image>(i => i.GroupId)
            .IsRequired(false);
        builder
            .HasOne<Profile>()
            .WithOne(p => p.Avatar)
            .HasForeignKey<Image>(i => i.ProfileId)
            .IsRequired(false);
        builder
            .HasOne<Story>()
            .WithMany(s => s.Images)
            .HasForeignKey(i => i.StoryId)
            .IsRequired(false);
    }
}
