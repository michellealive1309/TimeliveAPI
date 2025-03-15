using Timelive.Domain.Entities;
using Timelive.Domain.Interfaces;
using Timelive.Infrastructure.DataAccess;

namespace Timelive.Infrastructure.Repositories;

public class StoryRepository : Repository<Story>, IStoryRepository
{
    public StoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}
