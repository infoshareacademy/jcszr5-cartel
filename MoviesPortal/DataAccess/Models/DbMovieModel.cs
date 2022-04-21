using DataAccess.Models.EntityAssigments;
using DataAccess.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class DbMovieModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<DbCreativePersonModel> CreativePersons { get; set; }

        public int ProductionYear { get; set; }

        public Genre Genre { get; set; }

        public string Description { get; set; }

        public bool IsForKids { get; set; }

        public virtual ICollection<MovieCreativePerson> MovieCreativeRoles { get; set; }

        

    }
}