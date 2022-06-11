using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPortal.BusinessLayer.SearchEngine
{
    internal interface IPrinter
    {
        /// <summary>
        /// Show found movies, allows to navigate between movies
        /// </summary>
        public void PrintMovies(List<Movie> MovieList);
        /// <summary>
        /// allows to show description of selected movie
        /// </summary>
        public void ShowDescription(Movie movie);
    }
}
