using Microsoft.Extensions.Caching.Distributed;

namespace Timelive.Infrastructure.Interfaces;

public interface ICacheProvider<T> where T : class
{
    Task<T?> GetOrCreateAsync(string key, Func<Task<T?>> createItem, DistributedCacheEntryOptions options, CancellationToken cancellationToken = default);
}
