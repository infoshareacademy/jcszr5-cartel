using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.EntityAssigments
{
    public class TvSeriesCreativePerson
    {
        public int TvSeriesId { get; set; }
        public int CreativePersonId { get; set; }
        public TvSeriesModel TvSeries { get; set; }
        public CreativePersonModel CreativePerson { get; set; }
    }
}
