using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPortal.BusinessLayer
{
    public class MoviesService
    {
        MovieStore _movieStore = new MovieStore();

        public void AddNewMovie(Movie newMovie)
        {
            _movieStore.AddMovie(newMovie);
        }

    }
}
