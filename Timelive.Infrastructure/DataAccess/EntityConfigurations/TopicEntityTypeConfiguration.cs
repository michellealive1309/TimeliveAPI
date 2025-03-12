using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timelive.Domain.Entities;

namespace Timelive.Infrastructure.DataAccess.EntityConfigurations;

public class TopicEntityTypeConfiguration : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder.ToTable("topics");
        builder.HasKey(t => t.Id);

        builder
            .Property(t => t.Title)
            .HasMaxLength(255)
            .IsRequired();

        builder
            .HasMany<Story>()
            .WithOne(g => g.Topic)
            .HasForeignKey(t => t.TopicId)
            .IsRequired(false);
    }
}
