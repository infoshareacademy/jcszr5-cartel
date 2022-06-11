namespace MoviesPortalWebApp.Models
{
    public class EpisodeVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public virtual SeasonVM Season { get; set; }
    }
}
