using Microsoft.EntityFrameworkCore;
using Timelive.Domain.Entities;
using Timelive.Domain.Interfaces;
using Timelive.Infrastructure.DataAccess;

namespace Timelive.Infrastructure.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public Task<User?> GetUserByEmailAsync(string email)
    {
        return _context.Users
            .Where(u => u.Email == email)
            .FirstOrDefaultAsync();
    }
}
