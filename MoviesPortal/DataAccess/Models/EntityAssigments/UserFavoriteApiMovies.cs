using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.EntityAssigments
{
    public class UserFavoriteApiMovies
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int MovieId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        
    }
}
