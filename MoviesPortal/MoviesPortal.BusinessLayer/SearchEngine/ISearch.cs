using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPortal.BusinessLayer.SearchEngine
{
    internal interface ISearch
    {
        List<Movie> Search(string input);
    }
}
