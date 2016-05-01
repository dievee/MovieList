using System;
using System.Collections.Generic;
using ML.Domain.Abstract;
using ML.Domain.Entities;

namespace ML.Domain.Concrete
{
    public class EFMovieRepository : IMovieRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Movie> Movies
        {
            get { return context.Movies; }
        }
    }
}
