using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timelive.Domain.Entities;

namespace Timelive.Infrastructure.DataAccess.EntityConfigurations;

public class PurchasedStoryEntityTypeConfiguration : IEntityTypeConfiguration<PurchasedStory>
{
    public void Configure(EntityTypeBuilder<PurchasedStory> builder)
    {
        builder.ToTable("purchased_stories");

        builder.HasKey(ps => ps.Id);

        builder.HasIndex(ps => ps.StoryId);
        builder.HasIndex(ps => ps.UserId);

        builder
            .Property(ps => ps.StoryId)
            .IsRequired();
        builder
            .Property(ps => ps.UserId)
            .IsRequired();
        builder
            .Property(ps => ps.PurchasedDate)
            .IsRequired();
        builder
            .Property(ps => ps.Type)
            .HasConversion<string>()
            .IsRequired();

        builder.HasOne(ps => ps.Story)
            .WithMany()
            .HasForeignKey(ps => ps.StoryId);
        builder.HasOne(ps => ps.User)
            .WithMany()
            .HasForeignKey(ps => ps.UserId);
    }
}
