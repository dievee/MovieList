using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using MovieList.Models;
namespace MovieList.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string NickName { get; set; }
        public string Status { get; set; }

        public IEnumerable<Note> Notes { get; set; }
        public IEnumerable<Movie> Movies { get; set; }

        public virtual ICollection<UserMovie> UserMovies { get; set; }
    }
}