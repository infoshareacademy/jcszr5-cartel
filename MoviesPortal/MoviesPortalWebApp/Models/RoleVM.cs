using MoviesPortalWebApp.AssigmentsVM;

namespace MoviesPortalWebApp.Models
{
    public class RoleVM
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<RoleCreativeMovieVM> RoleCreativePersons { get; set; }
        public virtual ICollection<CreativePersonVM> CreativePersons { get; set; }

    }
}
