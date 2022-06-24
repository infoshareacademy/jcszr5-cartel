using DataAccess.Models;
using DataAccess.Models.EntityAssigments;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesPortalWebApp.AssigmentsVM;
using System.ComponentModel.DataAnnotations;

namespace MoviesPortalWebApp.Models
{
    public class MovieVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ProductionYear { get; set; }
        public string Description { get; set; }
        public string? PosterPath { get; set; }
        public string? TrailerUrl { get; set; }        
        public string? BackgroundPoster { get; set; }
        public string? ImdbRatio { get; set; }
        public bool IsForKids { get; set; }
        public bool IsApiModel { get; set; }
        public string Imdb_Id { get; set; }

        [Display(Name = "Genres")]
        public virtual IList<GenreVM> Genres { get; set; }

        public List<SelectListItem> selectedGenres { get; set; }
        public int[] GenresIds { get; set; }
       
        public virtual IList<RoleCreativeMovieVM> RoleCreativeMovie { get; set; }

        public List<SelectListItem> selectedActors { get; set; }
        public int[] ActorsIds { get; set; }

        public List<SelectListItem> selectedDirectors { get; set; }
        public int[] DirectorsIds { get; set; }

        public List<UserFavoriteMovies> UserFavoriteMovies { get; set; }
        public List<UserFavoriteTvSeries> UserFavoriteTvSeries { get; set; }

    }
}
