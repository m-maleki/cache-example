using cache_example.Infrastructure.Cache;
using cache_example.Infrastructure.Cache.MemoryCache;
using cache_example.Infrastructure.Ef.DbEntity;
using cache_example.Infrastructure.Ef.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualBasic;

namespace cache_example.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICityRepository _cityRepository;
        private readonly IInMemoryCache _memoryCache;

        public IndexModel(ICityRepository cityRepository, IInMemoryCache memoryCache)
        {
            _cityRepository = cityRepository;
            _memoryCache = memoryCache;
        }

        public void OnGet()
        {
            if (!_memoryCache.TryGetValue(CacheKey.Cities))
            {
                var result = _cityRepository.GetAll();
                _memoryCache.SetAbsolute(CacheKey.Cities, result, 10);
            }
        }
    }
}