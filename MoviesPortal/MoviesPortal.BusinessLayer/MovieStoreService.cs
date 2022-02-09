using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPortal.BusinessLayer
{
    public class MovieStoreService
    {
        public void AddNewMovie(Movie newMovie)
        {
            Movie.AddMovie(newMovie);
        }

        public List<Movie> GetAllMovies()
        {
            return Movie.GetMovies();
        }

        public void DeleteMovie(int movieIndex)
        {
            Movie.DeleteMovie(movieIndex);
        }
    }
}
