using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timelive.Domain.Entities;

namespace Timelive.Infrastructure.DataAccess.EntityConfigurations;

public class StoryEntityTypeConfiguration : IEntityTypeConfiguration<Story>
{
    public void Configure(EntityTypeBuilder<Story> builder)
    {
        builder.ToTable("stories");
        builder.HasKey(s => s.Id);

        builder.HasIndex(s => s.ParentId);
        builder.HasIndex(s => s.TopicId);
        builder.HasIndex(s => s.WriterGroupId);
        builder.HasIndex(s => s.WriterId);

        builder
            .Property(s => s.Title)
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(s => s.Content)
            .HasColumnType("longtext")
            .IsRequired();

        builder
            .Property(s => s.ContentType)
            .HasConversion<string>()
            .IsRequired();

        builder
            .Property(s => s.Timestamp)
            .IsRequired();

        builder
            .Property(s => s.ParentId)
            .IsRequired(false);

        builder
            .Property(s => s.CreatedAt)
            .IsRequired();

        builder
            .Property(s => s.UpdatedAt)
            .IsRequired();

        builder.HasOne(s => s.ParentStory)
            .WithMany()
            .HasForeignKey(s => s.ParentId)
            .IsRequired(false);
        builder.HasMany(s => s.PurchasedStories)
            .WithOne()
            .HasForeignKey(s => s.StoryId)
            .IsRequired(false);
        builder.HasOne(s => s.WriterGroup)
            .WithMany()
            .HasForeignKey(s => s.WriterGroupId)
            .IsRequired(false);
        builder.HasOne(s => s.Writer)
            .WithMany()
            .HasForeignKey(s => s.WriterId)
            .IsRequired();
        builder.HasMany(s => s.Images)
            .WithOne()
            .HasForeignKey(i => i.StoryId)
            .IsRequired(false);
        builder.HasMany(s => s.Likes)
            .WithOne(l => l.Story)
            .HasForeignKey(l => l.StoryId)
            .IsRequired(false);
    }
}
