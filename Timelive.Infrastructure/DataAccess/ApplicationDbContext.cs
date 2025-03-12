using Microsoft.EntityFrameworkCore;
using Timelive.Domain.Entities;
using Timelive.Infrastructure.DataAccess.EntityConfigurations;
using Timelive.Infrastructure.Interfaces;

namespace Timelive.Infrastructure.DataAccess;

public class ApplicationDbContext : DbContext
{
    private readonly IUserProvider _userProvider;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IUserProvider userProvider
    ) : base(options)
    {
        _userProvider = userProvider;
    }
    
    public DbSet<Group> Groups { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<PurchasedStory> PurchasedStories { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Story> Stories { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GroupEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ImageEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new LikeEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new StoryEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new SubscriptionEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ProfileEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new PurchasedStoryEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TopicEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSnakeCaseNamingConvention();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is Entity);

        foreach (var entityEntry in entries)
        {
            var entity = (Entity)entityEntry.Entity;
            entity.UpdatedAt = DateTime.UtcNow;
            switch (entityEntry.State)
            {
                case EntityState.Added:
                    entity.CreatedAt = DateTime.UtcNow;
                    break;
                case EntityState.Deleted:
                    entityEntry.State = EntityState.Modified;
                    entity.IsDeleted = true;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
