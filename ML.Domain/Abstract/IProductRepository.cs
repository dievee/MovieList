using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML.Domain.Entities;

namespace ML.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Movie> Movies { get; }
    }
}
