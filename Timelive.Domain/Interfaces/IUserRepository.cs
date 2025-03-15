using Timelive.Domain.Entities;

namespace Timelive.Domain.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetUserByEmailAsync(string email);
}
