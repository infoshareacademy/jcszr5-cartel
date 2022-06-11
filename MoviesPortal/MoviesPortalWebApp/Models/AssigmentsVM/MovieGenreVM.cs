using MoviesPortalWebApp.Models;

namespace MoviesPortalWebApp.AssigmentsVM
{
    public class MovieGenreVM
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int GenreId { get; set; }
        public MovieVM Movie { get; set; }
        public GenreVM Genre { get; set; }
    }
}