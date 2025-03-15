using Timelive.Domain.Entities;

namespace Timelive.Domain.Interfaces;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task<TEntity> AddAsync(TEntity entity);
    Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
    void Delete(TEntity entity);
    Task<bool> IsExistAsync(int id);
    Task<TEntity?> GetByIdAsync(int id);
    IQueryable<TEntity> GetAll();
    IQueryable<TEntity> GetAllNoTracking();
    void Update(TEntity entity);
    Task SaveChangesAsync();
}
