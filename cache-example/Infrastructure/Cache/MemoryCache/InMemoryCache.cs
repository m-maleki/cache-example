using Microsoft.Extensions.Caching.Memory;

namespace cache_example.Infrastructure.Cache.MemoryCache
{
    public class InMemoryCache : IInMemoryCache
    {

        private readonly IMemoryCache _memoryCache;

        public InMemoryCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void SetAbsolute<T>(string key, T value, int expirationTime)
        {
            MemoryCacheEntryOptions options = new MemoryCacheEntryOptions();

            options.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(expirationTime);

            _memoryCache.Set(key, value, options);
        }      
        
        public void SetSliding<T>(string key, T value, int expirationTime)
        {
            MemoryCacheEntryOptions options = new MemoryCacheEntryOptions();

            options.SlidingExpiration = TimeSpan.FromSeconds(expirationTime);

            _memoryCache.Set(key, value, options);
        }

        public T Get<T>(string key)
        {
            return (T)_memoryCache.Get(key);
        }

        public bool TryGetValue(string key)
        {
            return _memoryCache.TryGetValue(key, out var value);
        }

    }
}
