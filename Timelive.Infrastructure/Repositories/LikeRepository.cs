using Timelive.Domain.Entities;
using Timelive.Domain.Interfaces;
using Timelive.Infrastructure.DataAccess;

namespace Timelive.Infrastructure.Repositories;

public class LikeRepository : Repository<Like>, ILikeRepository
{
    public LikeRepository(ApplicationDbContext context) : base(context)
    {
    }
}
