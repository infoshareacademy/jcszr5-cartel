using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.ApiHandler.ApiModels;
using BusinessLogic.ApiHandler.ApiModels.ContentProvidersClasses;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;

namespace BusinessLogic.ApiHandler
{
    public class ApiClient
    {
        
        
        private readonly string _baseUrl = "https://api.themoviedb.org/3";
        private readonly string _apiKey = "api_key=1cf50e6248dc270629e802686245c2c8";
        private readonly string _alternateApiUrl = "https://omdbapi.com";
        private readonly string _alternateApiKey = "apikey=fc1fef96";

        public ApiClient()
        {

        }        
        
        public async Task<Movie> GetMovieDetails(int movieId)
        {
            var result = await _baseUrl
                .AppendPathSegment("movie")
                .AppendPathSegment(movieId.ToString())
                .SetQueryParams(_apiKey, "language=en-US")
                .GetStringAsync();
            var movie = JsonConvert.DeserializeObject<Movie>(result);
            return movie;
        }
        public async Task<List<Movie>> FindMoviesByTitle(string title, int page, bool isOnlyForAdults)
        {
            var result = await _baseUrl
                .AppendPathSegment("search")
                .AppendPathSegment("movie")
                .SetQueryParams(_apiKey, "language=en-US", $"query={title}", $"page={page}", $"include_adult={isOnlyForAdults}")
                .GetStringAsync();
            var searchResult = JsonConvert.DeserializeObject<MoviesSearchResult>(result);
            return searchResult.results;
        }
        public async Task<ProvidersStore> GetProviders(int movieId, ProviderPicker country)
        {
            var result = await _baseUrl
                .AppendPathSegment("movie")
                .AppendPathSegment(movieId.ToString())
                .AppendPathSegment("watch/providers")
                .SetQueryParams(_apiKey)
                .GetStringAsync();
            var providers = JsonConvert.DeserializeObject<Root>(result);
            return country switch
               {
                   ProviderPicker.PL => providers.Results.PL,
                   ProviderPicker.US => providers.Results.US,
                   _ => throw new NotImplementedException(),
               };
        }
        public async Task<PersonDetails> GetPersonDetails(int personId)
        {
            var result = await _baseUrl
                .AppendPathSegment("person")
                .AppendPathSegment(personId.ToString())
                .SetQueryParams(_apiKey, "language=en-US")
                .GetStringAsync();
            var person = JsonConvert.DeserializeObject<PersonDetails>(result);
            return person;
        }
        public async Task<List<Movie>> GetTrendingMoviesOfTheDay()
        {
            var result = await _baseUrl
                .AppendPathSegment("trending")
                .AppendPathSegment("movie")
                .AppendPathSegment("day")
                .SetQueryParams(_apiKey)
                .GetStringAsync();
            var searchResult = JsonConvert.DeserializeObject<MoviesSearchResult>(result);
            return searchResult.results;
        }
        public async Task<PersonsRoot> GetPersonsForMovie(int movieId)
        {
            var result = await _baseUrl
                .AppendPathSegment("movie")
                .AppendPathSegment(movieId)
                .AppendPathSegment("credits")
                .SetQueryParams(_apiKey, "language=en-US")
                .GetStringAsync();
            var persons = JsonConvert.DeserializeObject<PersonsRoot>(result);
            var cast = persons.Cast.Take(12).ToList();
            var crews = persons.Crew.Where(d => d.Job == "Director").ToList();
            return new PersonsRoot() {Cast = cast, Crew = crews};
        }
        public async Task<MoviesForPersonRoot> GetMoviesForPerson(int personId)
        {
            var result = await _baseUrl
                .AppendPathSegment("person")
                .AppendPathSegment(personId)
                .AppendPathSegment("movie_credits")
                .SetQueryParams(_apiKey, "language=en-US")
                .GetStringAsync();
            var movies = JsonConvert.DeserializeObject<MoviesForPersonRoot>(result);
            var actorInMovies = movies.Cast.Take(12).ToList();
            var directorInMovies = movies.Crew.Take(6).ToList();
            return new MoviesForPersonRoot() { Cast = actorInMovies, Crew = directorInMovies };
        }
        public async Task<RatingRoot> GetRatingForMovie(int movieId)
        {
            try
            {
                var result = await _alternateApiUrl
                .SetQueryParam(_alternateApiKey + "&i=tt" + movieId)
                .GetStringAsync();
                var ratingRoot = JsonConvert.DeserializeObject<RatingRoot>(result);
                return ratingRoot;
            }
            catch (Exception)
            {
                return new RatingRoot();
            }
            
        }
        public async Task<List<Cast>> FindPersonsByName(string name, int page)
        {
            var result = await _baseUrl
                .AppendPathSegment("search")
                .AppendPathSegment("person")
                .SetQueryParams(_apiKey, "language=en-US", $"query={name}", $"page={page}")
                .GetStringAsync();
            var searchResult = JsonConvert.DeserializeObject<PersonSearchResult>(result);
            return searchResult.results;
        }
    }
}
