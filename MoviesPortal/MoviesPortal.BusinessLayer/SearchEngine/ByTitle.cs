using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPortal.BusinessLayer.SearchEngine
{
    public class ByTitle : ISearch, IPrinter
    {

        private List<Movie> movies;
        
        public List<Movie> Search(string input)
        {
            MovieStoreService movieStoreService = new();
            movieStoreService.LoadMoviesFromJson(); //załaduj z pliku JSON do zmiennej MovieStore
            movies = MovieStore.GetMovies(); //zapisz w liscie movies wszystkie filmy

            var results = new List<Movie>();
            var isAnyWantedMovie = movies.Any(movie => movie.Title.ToLower().Contains(input.ToLower())); //chceck if is any searched movie, if not, display allert
            if(isAnyWantedMovie)
            {
                results = movies.Where(movie => movie.Title.ToLower().Contains(input.ToLower())).ToList();
            }
            else
            {
                Console.WriteLine("Nothing found. Probably there is no such film in the database. \nLet's find something different!");
                //results = null;
            }
            return results; //possible null reference. Only god know what will happen
        }

        void IPrinter.PrintMovies()
        {
            throw new NotImplementedException();
        }

        void IPrinter.ShowDescription()
        {
            throw new NotImplementedException();
        }
    }
    
}
