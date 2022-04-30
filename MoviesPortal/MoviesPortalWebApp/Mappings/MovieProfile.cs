using AutoMapper;
using DataAccess.Models;
using MoviesPortalWebApp.Models;

namespace MoviesPortalWebApp.Mappings
{
    public class MovieProfile : Profile
    {
       
            public MovieProfile()
            {
                CreateMap<MovieModel, Movie>().ReverseMap();
                CreateMap<MovieModel, EditMovie>().ReverseMap();
            }        
    }
}
