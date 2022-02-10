using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPortal.BusinessLayer.SearchEngine
{
    internal class ByActor : ISearch
    {
        private List<Movie> movies;
        public List<Movie> Search(string input)
        {
            MovieStoreService movieStoreService = new();
            movieStoreService.LoadMoviesFromJson(); //załaduj z pliku JSON do zmiennej MovieStore
            movies = MovieStore.GetMovies(); //zapisz w liscie movies wszystkie filmy
            
            var results = new List<Movie>();
            var actorList = new List<CreativePerson>();
            foreach (var movie in movies)
            {
                var isAnyWantedActor = movie.ActorList.Any(actor => actor.SurName.ToLower().Contains(input.ToLower()));
                if (isAnyWantedActor)
                {
                    results.Add(movie);
                }

            }
            
            return results; //possible null reference. Only god know what will happen
        }
    }
}
