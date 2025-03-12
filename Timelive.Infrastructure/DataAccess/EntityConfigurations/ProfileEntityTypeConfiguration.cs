using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timelive.Domain.Entities;

namespace Timelive.Infrastructure.DataAccess.EntityConfigurations;

public class ProfileEntityTypeConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.ToTable("profiles");
        builder.HasKey(p => p.Id);

        builder.HasIndex(p => p.UserId);

        builder
            .Property(p => p.DisplayName)
            .IsRequired()
            .HasMaxLength(255);
        builder
            .Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(320);

        builder
            .HasMany(p => p.Groups)
            .WithMany(g => g.Members)
            .UsingEntity<GroupMember>(
                j => j
                    .HasOne(gm => gm.Group)
                    .WithMany()
                    .HasForeignKey(gm => gm.GroupId),
                j => j
                    .HasOne(gm => gm.Profile)
                    .WithMany()
                    .HasForeignKey(gm => gm.ProfileId),
                j =>
                {
                    j.HasKey(gm => new { gm.GroupId, gm.ProfileId });
                    j.Property(gm => gm.Role)
                        .IsRequired();
                }
            );
        builder
            .HasMany(p => p.Likes)
            .WithOne()
            .HasForeignKey(l => l.ProfileId)
            .IsRequired(false);
    }
}
