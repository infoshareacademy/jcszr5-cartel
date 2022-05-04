using MoviesPortalWebApp.AssigmentsVM;
using System.ComponentModel.DataAnnotations;

namespace MoviesPortalWebApp.Models
{
    public class CreativePersonVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string? PhotographyPath { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<RoleCreativeMovieVM> RoleCreativeMovie { get; set; }

        //public virtual ICollection<RoleCreativeMovieVM> RoleCreativePersons { get; set; }
        //public virtual ICollection<RoleVM> Roles { get; set; }
    }
}
