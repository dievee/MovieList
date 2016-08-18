using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieList.Models
{
    public class Note
    {
        public int MovieId { get; set; }
        public string Poster { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IMDBRating { get; set; }
        public string EventDate { get; set; }
        public string IMDBLink { get; set; }
        public string Comment { get; set; }
        public string Mark { get; set; }

        public string AuthorUserName { get; set; }
        public string AuthorId { get; set; }

    }
}