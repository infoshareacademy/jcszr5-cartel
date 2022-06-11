namespace MoviesPortalWebApp.Models.AssigmentsVM
{
    public class TvSeriesGenreVM
    {
        public int TvSeriesId { get; set; }
        public int GenreId { get; set; }

        public TvSeriesVM TvSeries { get; set; }
        public GenreVM Genre { get; set; }

    }
}
