using System.ComponentModel.DataAnnotations.Schema;
namespace MovieList.Models
{
    public class Note
    {
        public int NoteId { get; set; }
  
        public string Comment { get; set; }
        public string Mark { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int? MovieId { get; set; }
        public Movie Movie { get; set; }

        [NotMapped]
        public string Poster { get; set; }
        [NotMapped]
        public string Title { get; set; }
        [NotMapped]
        public string Description { get; set; }
        [NotMapped]
        public string IMDBRating { get; set; }
        [NotMapped]
        public string EventDate { get; set; }
        [NotMapped]
        public string IMDBLink { get; set; }
    }
}