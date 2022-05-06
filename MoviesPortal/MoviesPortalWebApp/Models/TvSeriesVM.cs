using DataAccess.Models;
using DataAccess.Models.EntityAssigments;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesPortalWebApp.Models.AssigmentsVM;

namespace MoviesPortalWebApp.Models
{
    public class TvSeriesVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<GenreVM> Genres { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string? PosterPath { get; set; }
        public string? TrailerUrl { get; set; }
        public string? BackgroundPoster { get; set; }
        public string? ImdbRatio { get; set; }
        //public virtual ICollection<SeasonVM> Seasons { get; set; }
        public virtual ICollection<TvSeries_CreativeP_RoleVM> TvSeries_CreativeP_Role { get; set; }
        public virtual ICollection<TvSeriesGenreVM> TvSeriesGenres { get; set; }
        public virtual ICollection<SeasonVM> Seasons { get; set; }
        public int[] GenresIds { get; set; }
        public int[] ActorsIds { get; set; }
        public int[] DirectorsIds { get; set; }
        public List<SelectListItem> selectedGenres { get; set; }
        public List<SelectListItem> selectedActors { get; set; }
        public List<SelectListItem> selectedDirectors { get; set; }
    }
}
