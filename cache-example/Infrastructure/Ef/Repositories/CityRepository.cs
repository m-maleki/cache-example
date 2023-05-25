using cache_example.Infrastructure.Cache.MemoryCache;
using cache_example.Infrastructure.Ef.Common;
using cache_example.Infrastructure.Ef.DbEntity;

namespace cache_example.Infrastructure.Ef.Repositories;
public class CityRepository : ICityRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly IInMemoryCache _memoryCache;
    public CityRepository(AppDbContext appDbContext,
        IInMemoryCache memoryCache)
    {
        _appDbContext = appDbContext;
        _memoryCache = memoryCache;
    }

    public List<CityDbEntity> GetAll()
    {

        return _appDbContext.Cities.ToList();
    }
}