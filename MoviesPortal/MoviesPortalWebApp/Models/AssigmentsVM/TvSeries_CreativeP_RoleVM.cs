namespace MoviesPortalWebApp.Models.AssigmentsVM
{
    public class TvSeries_CreativeP_RoleVM
    {
        public int TvSeriesId { get; set; }
        public int CreativePersonId { get; set; }
        public int RoleId { get; set; }
        public TvSeriesVM TvSeries { get; set; }
        public CreativePersonVM CreativePerson { get; set; }
        public RoleVM Role { get; set; }
    }
}
