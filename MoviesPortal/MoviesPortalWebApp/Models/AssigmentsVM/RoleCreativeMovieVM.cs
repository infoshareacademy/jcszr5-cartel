using MoviesPortalWebApp.Models;

namespace MoviesPortalWebApp.AssigmentsVM
{
    public class RoleCreativeMovieVM
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int CreativePersonId { get; set; }
        public int MovieId { get; set; }
        public RoleVM Role { get; set; }
        public CreativePersonVM CreativePerson { get; set; }
        public MovieVM Movie { get; set; }
    }
}