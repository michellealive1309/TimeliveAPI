using Timelive.Domain.Entities;
using Timelive.Domain.Interfaces;
using Timelive.Infrastructure.DataAccess;

namespace Timelive.Infrastructure.Repositories;

public class PurchasedStoryRepository : Repository<PurchasedStory>, IPurchasedStoryRepository
{
    public PurchasedStoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}
