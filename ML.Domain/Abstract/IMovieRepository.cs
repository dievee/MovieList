using System;
using System.Collections.Generic;

using ML.Domain.Entities;

namespace ML.Domain.Abstract
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> Movies { get; }
    }
}
