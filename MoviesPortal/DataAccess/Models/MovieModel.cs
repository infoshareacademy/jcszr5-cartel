using DataAccess.Models.EntityAssigments;
using DataAccess.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class MovieModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<CreativePersonModel> CreativePersons { get; set; }

        public int ProductionYear { get; set; }

        public virtual ICollection<GenreModel> Genres { get; set; }

        public string Description { get; set; }
        public string? PosterPath { get; set; }
        public string? TrailerUrl { get; set; }
        public string? BackgroundPoster { get; set; }
        public string? ImdbRatio { get; set; }

        public bool IsForKids { get; set; }

        public virtual ICollection<MovieCreativePerson> MovieCreativePersons { get; set; }
        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
        public virtual ICollection<RoleCreativeMovie> RoleCreativeMovie { get; set; }

        

    }
}