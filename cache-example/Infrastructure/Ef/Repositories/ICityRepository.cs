using cache_example.Infrastructure.Ef.DbEntity;

namespace cache_example.Infrastructure.Ef.Repositories;
public interface ICityRepository
{
    List<CityDbEntity> GetAll();
}
