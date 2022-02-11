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
        void PrintMovies();
        /// <summary>
        /// allows to show description of selected movie
        /// </summary>
        void ShowDescription();
    }
}
