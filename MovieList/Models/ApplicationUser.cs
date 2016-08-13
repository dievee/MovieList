using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace MovieList.Models
{
    public class ApplicationUser : IdentityUser
    {
        //  public int Year { get; set; }

        public ICollection<Movie> Movies { get; set; }

        public ApplicationUser()
        {
            Movies = new List<Movie>();
        }
    }
}