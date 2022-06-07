using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MoviesPortalWebApp.Models.AdvancedViewModels
{
    public class MovieCreatingVM
    {
        public string Title { get; set; }

        [Display(Name = "Production year")]
        public int ProductionYear { get; set; }
        public string Description { get; set; }

        [Display(Name = "Poster URL")]
        public string? PosterPath { get; set; }

        [Display(Name = "Trailer URL")]
        public string? TrailerUrl { get; set; }

        [Display(Name = "Production year")]
        public string? BackgroundPoster { get; set; }
        public string? ImdbRatio { get; set; }

        [Display(Name = "Is for kids?")]
        public bool IsForKids { get; set; }
        public SelectList Genres { get; set; }
        public SelectList Actors { get; set; }
        public SelectList Directors { get; set; }
    }
}
