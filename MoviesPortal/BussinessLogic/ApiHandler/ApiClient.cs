using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.ApiHandler.ApiModels;
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
    }
}
