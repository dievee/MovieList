using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using ML.Domain.Entities;

namespace ML.Domain.Concrete
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("MovieListDb") { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
