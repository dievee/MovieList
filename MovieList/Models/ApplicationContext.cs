using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MovieList.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("AppContext")
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<UserMovie> UserMovies { get; set; }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMovie>()
                .HasKey(c => new { c.UserId, c.MovieId });

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(c => c.UserMovies)
                .WithRequired()
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Movie>()
                .HasMany(c => c.UserMovies)
                .WithRequired()
                .HasForeignKey(c => c.MovieId);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

    }
}