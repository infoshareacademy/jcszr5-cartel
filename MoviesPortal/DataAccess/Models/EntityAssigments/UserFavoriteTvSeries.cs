using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.EntityAssigments
{
    public class UserFavoriteTvSeries
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int TvSeriesId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public TvSeriesModel TvSeries { get; set; }
    }
}
