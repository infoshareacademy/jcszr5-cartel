using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.EntityAssigments
{
    public class MovieCreativePerson
    {
        public int MovieId { get; set; }
        public int CreativePersonId { get; set; }
        public DbMovieModel Movie { get; set; }
        public DbCreativePersonModel CreativePerson { get; set; }
    }
}
