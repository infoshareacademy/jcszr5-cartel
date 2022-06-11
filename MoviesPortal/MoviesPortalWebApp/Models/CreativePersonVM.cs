using MoviesPortalWebApp.AssigmentsVM;
using MoviesPortalWebApp.Models.AssigmentsVM;
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
        public virtual ICollection<RoleVM> Roles { get; set; }
        //public virtual ICollection<MovieCreativePersonVM> MovieCreativePersons { get; set; }
        public virtual ICollection<TvSeries_CreativeP_RoleVM> TvSeries_CreativeP_Role { get; set; }

    }
}
