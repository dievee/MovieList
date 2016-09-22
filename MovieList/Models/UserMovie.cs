using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieList.Models
{
    public class UserMovie
    {
        public string UserId { get; set; }
        public int MovieId { get; set; }
        public bool IsLooked { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}