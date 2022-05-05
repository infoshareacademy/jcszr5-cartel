using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.EntityAssigments
{
    public class UserFavourities 
    {

        public int UserId { get; set; }
        public int MovieId { get; set; }
        public int TvSeriesId { get; set; }
        public IdentityUser Identity { get; set; }
        public MovieModel Movie { get; set; }
        public TvSeriesModel TvSeries { get; set; }
    }
}
