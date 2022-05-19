using AutoMapper;
using DataAccess.Models;
using DataAccess.Models.EntityAssigments;
using MoviesPortalWebApp.AssigmentsVM;
using MoviesPortalWebApp.Models;

namespace MoviesPortalWebApp.Mappings
{
    public class MovieProfile : Profile
    {

        public MovieProfile()
        {
            CreateMap<MovieModel, MovieVM>();
            CreateMap<MovieGenre, MovieGenreVM>();
            CreateMap<GenreModel, GenreVM>();
            CreateMap<CreativePersonModel, CreativePersonVM>().ReverseMap();
            CreateMap<RoleModel, RoleVM>();
            CreateMap<Movie_CreativeP_Role, RoleCreativeMovieVM>().ReverseMap();
            //CreateMap<MovieCreativePerson, MovieCreativePersonVM>();
            CreateMap<CreativePersonModel, CreativePersonVM>();
        }
               
    }
}
