using Timelive.Domain.Entities;
using Timelive.Domain.Interfaces;
using Timelive.Infrastructure.DataAccess;

namespace Timelive.Infrastructure.Repositories;

public class GroupRepository : Repository<Group>, IGroupRepository
{
    public GroupRepository(ApplicationDbContext context) : base(context)
    {
    }
}
