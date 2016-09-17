using System;
using System.Collections.Generic;

namespace MovieList.Models
{
    public class Movie : MovieFull
    {
        public int MovieId { get; set; }
        public string Poster { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IMDBRating { get; set; }
        public string EventDate { get; set; }
        public string IMDBLink { get; set; }

        public IEnumerable<Note> Notes { get; set; }
    }

    public class SearchMovie
    {
        public string Title { get; set; }
        public int Year { get; set; }
    }
}
//public string Comment { get; set; }
//public string Mark { get; set; }
//public DateTime? NotedDate { get; set; }
//public string UserId { get; set; }
//public ApplicationUser User { get; set; }