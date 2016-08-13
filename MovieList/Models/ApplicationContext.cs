using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MovieList.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("AppContext") { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}