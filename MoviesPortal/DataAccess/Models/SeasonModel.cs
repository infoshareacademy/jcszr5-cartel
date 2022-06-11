using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class SeasonModel
    {
        public int Id { get; set; }
        public int SeasonNumber { get; set; }
        public virtual ICollection<EpisodeModel> Episodes { get; set; }        
        public virtual TvSeriesModel TvSeries { get; set; }
    }
}