using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace MovieList.Models
{
    public class ApplicationUser : IdentityUser
    {

        public IEnumerable<Note> Notes { get; set; }

    }
}