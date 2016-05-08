using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.Domain.Entities
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Mark { get; set; }
        public string Category { get; set; }

        public int? UserId { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
