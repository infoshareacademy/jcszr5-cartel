using DataAccess.Models.EntityAssigments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class TvSeriesModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<GenreModel> Genres { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string? PosterPath { get; set; }
        public string? TrailerUrl { get; set; }
        public string? BackgroundPoster { get; set; }
        public string? ImdbRatio { get; set; }
        public virtual ICollection<SeasonModel> Seasons { get; set; }
        public virtual ICollection<CreativePersonModel> CreativePersons { get; set; }        
        public virtual ICollection<TvSeriesGenre> TvSeriesGenres { get; set; }
    }
}
