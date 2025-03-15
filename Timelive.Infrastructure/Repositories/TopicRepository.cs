using Timelive.Domain.Entities;
using Timelive.Domain.Interfaces;
using Timelive.Infrastructure.DataAccess;

namespace Timelive.Infrastructure.Repositories;

public class TopicRepository : Repository<Topic>, ITopicRepository
{
    public TopicRepository(ApplicationDbContext context) : base(context)
    {
    }
}
