using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.EntityAssigments
{
    public class TvSeries_CreativeP_Role
    {
        public int TvSeriesId { get; set; }
        public int CreativePersonId { get; set; }
        public int RoleId { get; set; }
        public TvSeriesModel TvSeries { get; set; }
        public CreativePersonModel CreativePerson { get; set; }
        public RoleModel Role { get; set; }
    }
}
