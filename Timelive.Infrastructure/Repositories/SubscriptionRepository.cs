using Timelive.Domain.Entities;
using Timelive.Domain.Interfaces;
using Timelive.Infrastructure.DataAccess;

namespace Timelive.Infrastructure.Repositories;

public class SubscriptionRepository : Repository<Subscription>, ISubscriptionRepository
{
    public SubscriptionRepository(ApplicationDbContext context) : base(context)
    {
    }
}
