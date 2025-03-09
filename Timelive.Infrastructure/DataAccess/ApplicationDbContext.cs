using Microsoft.EntityFrameworkCore;
using Timelive.Domain.Entities;
using Timelive.Infrastructure.DataAccess.EntityConfigurations;
using Timelive.Infrastructure.Providers;

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
    
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
