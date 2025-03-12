using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timelive.Domain.Entities;

namespace Timelive.Infrastructure.DataAccess.EntityConfigurations;

public class SubscriptionEntityTypeConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.ToTable("subscriptions");
        builder.HasKey(s => s.Id);

        builder.HasIndex(s => s.ProfileId);

        builder
            .Property(s => s.Type)
            .HasConversion<string>()
            .IsRequired();

        builder.HasOne<Profile>()
            .WithMany(p => p.Subscriptions)
            .HasForeignKey(s => s.ProfileId)
            .IsRequired();
    }
}
