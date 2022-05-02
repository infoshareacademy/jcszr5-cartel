using DataAccess.Models.EntityAssigments;
using System.ComponentModel.DataAnnotations;

namespace MoviesPortalWebApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }

        //public virtual ICollection<CreativePersonModel> CreativePersons { get; set; }

        public int ProductionYear { get; set; }

        //public virtual ICollection<GenreModel> Genres { get; set; }

        public string Description { get; set; }
        public string? PosterPath { get; set; }
        public string? TrailerUrl { get; set; }

        public bool IsForKids { get; set; }

        public virtual ICollection<MovieCreativePerson> MovieCreativePersons { get; set; }
        [Display(Name = "Genres")]
        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
