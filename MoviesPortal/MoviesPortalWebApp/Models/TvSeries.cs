using DataAccess.Models;

namespace MoviesPortalWebApp.Models
{
    public class TvSeries
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public virtual IList<GenreModel>? Genres { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string? PosterPath { get; set; }
        public string? TrailerUrl { get; set; }
    }
}
