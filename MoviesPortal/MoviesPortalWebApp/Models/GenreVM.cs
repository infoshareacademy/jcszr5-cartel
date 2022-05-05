using MoviesPortalWebApp.AssigmentsVM;
using MoviesPortalWebApp.Models.AssigmentsVM;

namespace MoviesPortalWebApp.Models
{
    public class GenreVM
    {
        public int Id { get; set; }
        public string Genre { get; set; }
        public virtual ICollection<MovieGenreVM> MovieGenres { get; set; }
        public virtual ICollection<TvSeriesGenreVM> TvSeriesGenres { get; set; }

    }
}