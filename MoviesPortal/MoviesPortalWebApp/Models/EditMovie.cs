using DataAccess.Models.EntityAssigments;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MoviesPortalWebApp.Models
{
    public class EditMovie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int ProductionYear { get; set; }

        public string Description { get; set; }
        public string? PosterPath { get; set; }
        public string? TrailerUrl { get; set; }

        public bool IsForKids { get; set; }

        public List<SelectListItem> selectedGenres { get; set; }
        public int[] GenresIds { get; set; } 

        public List<SelectListItem> selectedPersons { get; set; }
        public int[] PersonsIds { get; set; }

    }
}
