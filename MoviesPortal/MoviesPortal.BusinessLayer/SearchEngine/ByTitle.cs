using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPortal.BusinessLayer.SearchEngine
{
    public class ByTitle : ISearch
    {
        
        private List<Movie> movies = null; // Todo load from json file 
        
        public List<Movie> Search(string input)
        {
            var results = new List<Movie>();
            var isAnyWantedMovie = movies.Any(movie => movie.Title.ToLower().Contains(input.ToLower())); //chceck if is any searched movie, if not, display allert
            if(isAnyWantedMovie)
            {
                results = movies.Where(movie => movie.Title.ToLower().Contains(input.ToLower())).ToList();
            }
            else
            {
                Console.WriteLine("Nothing found. Probably there is no such film in the database. \nLet's find something different!");
                results = null;
            }
            return results; //possible null reference. Only god know what will happen
        }
    }
    
}
