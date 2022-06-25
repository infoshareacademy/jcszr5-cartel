using AutoMapper;
using BusinessLogic.ApiHandler.ApiModels;
using BusinessLogic.ApiHandler.ApiModels.ContentProvidersClasses;
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
            CreateMap<MovieModel, MovieVM>().ReverseMap();
            CreateMap<MovieGenre, MovieGenreVM>().ReverseMap();
            CreateMap<GenreModel, GenreVM>().ReverseMap();
            CreateMap<CreativePersonModel, CreativePersonVM>().ReverseMap();
            CreateMap<RoleModel, RoleVM>().ReverseMap();
            CreateMap<Movie_CreativeP_Role, RoleCreativeMovieVM>()
                //.ForMember(d => d.Id, o=>o.MapFrom(s => s.MovieId))
                .ReverseMap();            
            CreateMap<CreativePersonModel, CreativePersonVM>();
            CreateMap<CommentVM, CommentModel>()
                .ForMember(d => d.PublishedAt, o => o.MapFrom(s => DateTime.ParseExact(s.PublishedAt, "MM/dd/yyyy HH:mm", null)))
                .ForMember(d => d.CommentContent, o => o.MapFrom(s => s.Content))
                .ForMember(d => d.UserId, o => o.MapFrom(s => s.UserId))
                .ReverseMap();

            //Api Mappings

            CreateMap<Genre, GenreVM>()
                .ForMember(d => d.Genre, o => o.MapFrom(s => s.Name)).ReverseMap();

            CreateMap<UserFavoriteApiMovies, UserFavoriteMovies>().ReverseMap();
                

            CreateMap<Cast, CreativePersonVM>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name.Split(' ', ' ').First()))
                .ForMember(d => d.SurName, o => o.MapFrom(s => s.Name.Split(' ', ' ').Last()))
                .ForMember(d => d.PhotographyPath, o => o.MapFrom(s => s.Profile_Path)).ReverseMap()
                ;

            CreateMap<PersonDetails, CreativePersonVM>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name.Split(' ', ' ').First()))
                .ForMember(d => d.SurName, o => o.MapFrom(s => s.Name.Split(' ', ' ').Last()))
                .ForMember(d => d.PhotographyPath, o => o.MapFrom(s => "https://image.tmdb.org/t/p/w600_and_h900_bestv2" + s.Profile_Path))
                .ForMember(d => d.DateOfBirth, o => o.MapFrom(s => DateTime.Parse(s.Birthday)))
                .ForMember(d => d.Biography, o => o.MapFrom(s => s.Biography));


            CreateMap<Crew, CreativePersonVM>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name.Split(' ', ' ').First()))
                .ForMember(d => d.SurName, o => o.MapFrom(s => s.Name.Split(' ', ' ').Last()))
                .ForMember(d => d.PhotographyPath, o => o.MapFrom(s => s.Profile_Path)).ReverseMap();


            CreateMap<Movie, MovieVM>()
                .ForMember(d => d.Title, o => o.MapFrom(s => s.Title))
                .ForMember(d => d.ProductionYear, o => o.MapFrom(s => s.Release_Date.Substring(0, 4)))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.Overview))
                .ForMember(d => d.PosterPath, o => o.MapFrom(s => "https://image.tmdb.org/t/p/original" + s.Poster_Path))
                .ForMember(d => d.BackgroundPoster, o => o.MapFrom(s => "https://image.tmdb.org/t/p/original" + s.Backdrop_Path))
                .ForMember(d => d.ImdbRatio, o => o.MapFrom(s => s.Vote_Average.ToString()))
                .ForMember(d => d.IsForKids, o => o.MapFrom(s => !s.Adult))
                .ForMember(d => d.Genres, o => o.MapFrom(s => s.Genres))
                .ForMember(d => d.Imdb_Id, o => o.MapFrom(s => s.Imdb_Id)).ReverseMap();

            CreateMap<Provider, ProviderVM>().ReverseMap();


            CreateMap<ProvidersStore, ProvidersStoreVM>()
                .ForMember(d => d.Buy, o => o.MapFrom(s => s.Buy))
                .ForMember(d => d.Flatrate, o => o.MapFrom(s => s.Flatrate))
                .ForMember(d => d.Link, o => o.MapFrom(s => s.Link))
                .ForMember(d => d.Rent, o => o.MapFrom(s => s.Rent)).ReverseMap();

            CreateMap<Rating, RatingVM>().ReverseMap();

            CreateMap<RatingRoot, RatingRootVM>().ReverseMap();
        }
               
    }
}
