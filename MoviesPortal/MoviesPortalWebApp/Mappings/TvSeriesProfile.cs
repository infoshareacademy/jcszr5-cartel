using AutoMapper;
using DataAccess.Models;
using DataAccess.Models.EntityAssigments;
using MoviesPortalWebApp.Models;
using MoviesPortalWebApp.Models.AssigmentsVM;

namespace MoviesPortalWebApp.Mappings
{
    public class TvSeriesProfile : Profile
    {
        public TvSeriesProfile()
        {
            CreateMap<TvSeriesModel, TvSeriesVM>().ReverseMap();
            CreateMap<GenreModel, GenreVM>();
            CreateMap<TvSeriesGenre, TvSeriesGenreVM>();
            CreateMap<CreativePersonModel, CreativePersonVM>().ReverseMap();
            CreateMap<RoleModel, RoleVM>();
            CreateMap<TvSeries_CreativeP_Role, TvSeries_CreativeP_RoleVM>();
            CreateMap<SeasonModel, SeasonVM>().ReverseMap();
            CreateMap<EpisodeModel, EpisodeVM>();
        }
    }
}
