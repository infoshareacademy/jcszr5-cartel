using MoviesPortalWebApp.Models;

namespace MoviesPortalWebApp.AssigmentsVM
{
    public class MovieCreativePersonVM
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int CreativePersonId { get; set; }
        public MovieVM Movie { get; set; }
        public CreativePersonVM CreativePerson { get; set; }
    }
}