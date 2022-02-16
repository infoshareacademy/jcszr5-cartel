using MoviesPortal.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using MoviesPortal.DataLayer.Models;
using System.Text.Encodings.Web;

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


        public List<Movie> GetMoviesByGenre(Genre movieGenre)
        {
            return MovieStore.GetMoviesByGenre(movieGenre);
        }

        public void SaveMoviesToJson()
        {
            var writeIndentedOption = new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping }; //formatuj plik Json
            IList<Movie> moviesToSave = MovieStore.GetMovies();
            var json = JsonSerializer.Serialize(moviesToSave, writeIndentedOption); //ustaliłem formatowanie pliku, żeby nie zapisywał wszystkiego w jednej lini. (Mateusz)
            File.WriteAllText(moviesPath, json);
        }


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
        }
    }
}