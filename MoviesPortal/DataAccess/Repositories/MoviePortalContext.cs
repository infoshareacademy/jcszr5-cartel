using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    public class MoviePortalContext : DbContext
    {

        public MoviePortalContext() : base("MoviePortalContext")
        {
        }
        public DbSet<DbMovieModel> Movies { get; set; }
    }
}
