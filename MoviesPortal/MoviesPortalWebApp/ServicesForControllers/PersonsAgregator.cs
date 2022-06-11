using AutoMapper;
using BusinessLogic.ApiHandler;
using BusinessLogic.ApiHandler.ApiModels;
using BusinessLogic.Enums;
using MoviesPortalWebApp.Models;

namespace MoviesPortalWebApp.ServicesForControllers
{
       
    public class PersonsAgregator
    {
        private readonly IMapper _mapper;
        private readonly ApiClient client;

        public PersonsAgregator(IMapper mapper, ApiClient _client)
        {
            _mapper = mapper;
            client = _client;
        }

        public async Task<List<CreativePersonVM>> GetPersonsForMovie(MovieVM movie, CastOrCrewPicker castOrCrew)
        {
            List<CreativePersonVM> actorList = new();
            List<CreativePersonVM> directorList = new();
            PersonsRoot personsFromApi = new();


            if (!movie.IsApiModel)
            {
                actorList = movie.RoleCreativeMovie.Where(d => d.Role.RoleName == "Actor").Select(c => c.CreativePerson).ToList();
                directorList = movie.RoleCreativeMovie.Where(d => d.Role.RoleName == "Director").Select(c => c.CreativePerson).ToList();
            }
            else
            {
                personsFromApi = await client.GetPersons(movie.Id);
                var directors = personsFromApi.Crew;
                directorList = _mapper.Map<List<CreativePersonVM>>(directors);
                var actors = personsFromApi.Cast;
                actorList = _mapper.Map<List<CreativePersonVM>>(actors);
            }
            return castOrCrew switch
            {
                CastOrCrewPicker.Cast => actorList,
                CastOrCrewPicker.Crew => directorList,
            };
        }
    }
}
