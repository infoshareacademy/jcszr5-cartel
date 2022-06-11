namespace DataAccess.Models
{
    public class EpisodeModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public virtual SeasonModel Season { get; set; }
    }
}