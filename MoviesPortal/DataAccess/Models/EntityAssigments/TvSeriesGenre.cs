using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.EntityAssigments
{
    public class TvSeriesGenre
    {
        public int TvSeriesId { get; set; }
        public int GenreId { get; set; }
        
        public TvSeriesModel TvSeries { get; set; }
        public GenreModel Genre { get; set; }
        
    }
}
