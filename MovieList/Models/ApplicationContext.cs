﻿using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MovieList.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("AppContext") { }

        public DbSet<Movie> Movies { get; set; }
      //  public DbSet<ApplicationUser> AppUsers { get; set; }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}