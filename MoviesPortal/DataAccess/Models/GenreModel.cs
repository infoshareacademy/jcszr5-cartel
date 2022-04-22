using DataAccess.Models.EntityAssigments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class GenreModel
    {
        public int Id { get; set; }
        public string Genre { get; set; }
        public virtual ICollection<MovieModel> Movies { get; set; }
        public virtual ICollection<TvSeriesModel> TvSeries { get; set; }
        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
        public virtual ICollection<TvSeriesGenre> TvSeriesGenres { get; set; }

    }
}
