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
            //Database.SetInitializer<ApplicationContext>(null);// Remove default initializer
            //Configuration.ProxyCreationEnabled = false;
            //Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<UserMovie> UserMovies { get; set; }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }

        ////Identity and Authorization
        //public DbSet<UserLogin> UserLogins { get; set; }
        //public DbSet<UserClaim> UserClaims { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }

        //// ... your custom DbSets
        //public DbSet<RoleOperation> RoleOperations { get; set; }

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

            //// Configure Asp Net Identity Tables
            //modelBuilder.Entity<IUser>().ToTable("User");
            //modelBuilder.Entity<User>().Property(u => u.PasswordHash).HasMaxLength(500);
            //modelBuilder.Entity<User>().Property(u => u.Stamp).HasMaxLength(500);
            //modelBuilder.Entity<User>().Property(u => u.PhoneNumber).HasMaxLength(50);

            //modelBuilder.Entity<Role>().ToTable("Role");
            //modelBuilder.Entity<UserRole>().ToTable("UserRole");
            //modelBuilder.Entity<UserLogin>().ToTable("UserLogin");
            //modelBuilder.Entity<UserClaim>().ToTable("UserClaim");
            //modelBuilder.Entity<UserClaim>().Property(u => u.ClaimType).HasMaxLength(150);
            //modelBuilder.Entity<UserClaim>().Property(u => u.ClaimValue).HasMaxLength(500);
        }

    }
}