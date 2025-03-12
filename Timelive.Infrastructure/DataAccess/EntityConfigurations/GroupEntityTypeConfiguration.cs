using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Timelive.Domain.Entities;

namespace Timelive.Infrastructure.DataAccess.EntityConfigurations;

public class GroupEntityTypeConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable("groups");
        builder.HasKey(g => g.Id);

        builder
            .Property(g => g.Name)
            .HasMaxLength(255)
            .IsRequired();
        builder
            .Property(g => g.Description)
            .HasMaxLength(1000)
            .IsRequired(false);

        builder
            .HasOne(g => g.Avatar)
            .WithMany()
            .HasForeignKey(g => g.AvatarId)
            .IsRequired(false);
        builder
            .HasMany(g => g.Members)
            .WithMany(p => p.Groups)
            .UsingEntity<GroupMember>(
                j => j
                    .HasOne(gm => gm.Profile)
                    .WithMany()
                    .HasForeignKey(gm => gm.ProfileId),
                j => j
                    .HasOne(gm => gm.Group)
                    .WithMany()
                    .HasForeignKey(gm => gm.GroupId),
                j => j.HasKey(gm => new { gm.GroupId, gm.ProfileId })
            );
        builder
            .HasMany(g => g.Stories)
            .WithOne()
            .HasForeignKey(s => s.WriterGroupId)
            .IsRequired(false);
    }
}
