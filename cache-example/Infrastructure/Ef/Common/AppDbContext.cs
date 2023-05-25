using cache_example.Infrastructure.Ef.DbEntity;
using Microsoft.EntityFrameworkCore;

namespace cache_example.Infrastructure.Ef.Common;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<CityDbEntity> Cities { get; set; }
}
