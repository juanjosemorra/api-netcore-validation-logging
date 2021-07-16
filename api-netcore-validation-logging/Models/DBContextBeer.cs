using Microsoft.EntityFrameworkCore;

namespace api_netcore_validation_logging.Models
{
    public class DBContextBeer: DbContext
    {
        public DbSet<Beer> Beers { get; set; }
        public DBContextBeer(DbContextOptions option): base(option)
        {
            
        }
    }
}
