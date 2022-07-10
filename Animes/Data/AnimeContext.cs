using Microsoft.EntityFrameworkCore;

namespace Animes.Data
{
    public class FrutaContext : DbContext
    {
        public FrutaContext(DbContextOptions<FrutaContext> options) : base(options)
        {

        }

        public DbSet<Fruta> Frutas { get; set; }
    }
}
