using System.ComponentModel.DataAnnotations.Schema;

namespace MovieList.Models
{
    
    public class MovieFull 
    {
        [NotMapped]
        public string UserName {get; set;}
    }
}