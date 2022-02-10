using MoviesPortal.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using MoviesPortal.DataLayer.Models;


namespace MoviesPortal.BusinessLayer
{
    public class MovieStoreService
    {
        private string moviesPath = Config.moviesDbPath;

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
<<<<<<< HEAD

        public List<Movie> GetMoviesByGenre(Genre movieGenre)
        {
            return MovieStore.GetMoviesByGenre(movieGenre);
=======
        /// <summary>
        /// Saves contents of Movie Store to Json
        /// </summary>
        public void SaveMoviesToJson()
        {
            IList<Movie> moviesToSave = MovieStore.GetMovies();
            var json = JsonSerializer.Serialize(moviesToSave);
            File.WriteAllText(moviesPath, json);
        }

        /// <summary>
        /// Clears contents of Movies Store and replaces it with loaded movies from Json
        /// </summary>
        public void LoadMoviesFromJson()
        {
            MovieStore.ClearStoreContent();
            string jsonFromFile = File.ReadAllText(moviesPath);
            List<Movie> moviesFromFile = JsonSerializer.Deserialize<List<Movie>>(jsonFromFile);
            if (moviesFromFile.Count > 0)
            {
                foreach (var movie in moviesFromFile)
                {
                    MovieStore.AddMovie(movie);
                }
            }
            else
            {
                Console.WriteLine("There is nothing to load");
            }
>>>>>>> e1e9ff2d34e965a4babdd5f5ad5f56a7fe22d4ad
        }
    }
}