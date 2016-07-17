using System.Data.Entity;

namespace MovieList.Models
{
    public class AppContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}