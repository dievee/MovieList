using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using MovieList.Models;
namespace MovieList.Models
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<Note> Notes { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
    }
}