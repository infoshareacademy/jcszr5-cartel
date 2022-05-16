using DataAccess.Models.EntityAssigments;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Full name")]
        public string FullName { get; set; }
        public List<UserFavoriteMovies> UserFavoriteMovies { get; set; }
        public List<UserFavoriteTvSeries> UserFavoriteTvSeries { get; set; }
    }
}
