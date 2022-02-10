using MoviesPortal.DataLayer;
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
            MovieStore.AddMovie(newMovie);
        }

        public List<Movie> GetAllMovies()
        {
            return MovieStore.GetMovies();
        }

        public void DeleteMovie(int movieIndex)
        {
            MovieStore.DeleteMovie(movieIndex);
        }

        public List<Movie> GetMoviesByGenre(Genre movieGenre)
        {
            return MovieStore.GetMoviesByGenre(movieGenre);
        }
    }
}
