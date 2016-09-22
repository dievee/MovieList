using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieList.Models
{
    public class UserMovies
    {
        public string UserId { get; set; }
        public int MovieId { get; set; }
        public bool IsLooked { get; set; }
    }
}