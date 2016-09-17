using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MovieList.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("AppContext")
        {
            //this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Movie> Movies { get; set; }

        //  public DbSet<ApplicationUser> AppUsers { get; set; }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}