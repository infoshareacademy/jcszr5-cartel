namespace MoviesPortalWebApp.Models
{
    public class SeasonVM
    {
        public int Id { get; set; }
        public int SeasonNumber { get; set; }
        public virtual ICollection<EpisodeVM> Episodes { get; set; }
        public virtual TvSeriesVM TvSeries { get; set; }
    }
}
