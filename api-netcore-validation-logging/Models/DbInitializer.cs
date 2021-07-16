using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_netcore_validation_logging.Models
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var _context = new DBContextBeer(serviceProvider.GetRequiredService<DbContextOptions<DBContextBeer>>()))
            {

                if (_context.Beers.Any())
                {
                    return;
                }

                _context.Beers.AddRange(
                    new Beer { beerId = 1, name = "Rubia", description = "Descripcion" }
                 );

                _context.SaveChanges();
            }
        }
    }
}
