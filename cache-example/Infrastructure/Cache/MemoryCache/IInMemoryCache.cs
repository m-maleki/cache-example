using Microsoft.Extensions.Caching.Memory;

namespace cache_example.Infrastructure.Cache.MemoryCache;
public interface IInMemoryCache
{
    void SetAbsolute<T> (string key , T value ,int expirationTime );
    void SetSliding<T> (string key , T value ,int expirationTime );
    T Get<T>(string key);
    bool TryGetValue(string key);
}
