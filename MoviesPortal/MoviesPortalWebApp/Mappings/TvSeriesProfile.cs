using AutoMapper;
using DataAccess.Models;
using MoviesPortalWebApp.Models;

namespace MoviesPortalWebApp.Mappings
{
    public class TvSeriesProfile : Profile
    {
        public TvSeriesProfile()
        {
            CreateMap<TvSeriesModel, TvSeries>().ReverseMap();
        }
    }
}
