using Timelive.Domain.Entities;
using Timelive.Domain.Interfaces;
using Timelive.Infrastructure.DataAccess;

namespace Timelive.Infrastructure.Repositories;

public class ImageRepository : Repository<Image>, IImageRepository
{
    public ImageRepository(ApplicationDbContext context) : base(context)
    {
    }
}
