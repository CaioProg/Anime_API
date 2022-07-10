using Animes.Models;
using Microsoft.EntityFrameworkCore;

namespace Animes.Data
{
    public class AnimeContext : DbContext
    {
        public AnimeContext(DbContextOptions<AnimeContext> options) : base(options)
        {

        }

        public DbSet<Anime> Animes { get; set; }
    }
}
