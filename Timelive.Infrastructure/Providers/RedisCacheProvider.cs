
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Timelive.Infrastructure.Interfaces;

namespace Timelive.Infrastructure.Providers;

public class RedisCacheProvider<T> : ICacheProvider<T> where T : class
{
    private readonly IDistributedCache _cache;

    public RedisCacheProvider(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task<T?> GetOrCreateAsync(string key, Func<Task<T?>> query, DistributedCacheEntryOptions options, CancellationToken cancellationToken = default)
    {
        var data = await _cache.GetStringAsync(key, cancellationToken);

        if (!string.IsNullOrWhiteSpace(data))
        {
            return JsonSerializer.Deserialize<T>(data);
        }

        var value = await query();
        if (value == default)
        {
            return value;
        }

        await _cache.SetStringAsync(key, JsonSerializer.Serialize(value), options, cancellationToken);

        return value;
    }
}
