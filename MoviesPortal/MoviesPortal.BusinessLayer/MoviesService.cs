using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPortal.BusinessLayer
{
    public class MoviesService
    {
        public void AddNewMovie(Movie newMovie)
        {
            MovieStore.AddMovie(newMovie);
        }

    }
}
