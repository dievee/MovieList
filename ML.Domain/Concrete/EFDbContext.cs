using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML.Domain.Entities;
using System.Data.Entity;

namespace ML.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}
