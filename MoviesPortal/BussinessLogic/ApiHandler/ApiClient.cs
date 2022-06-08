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

        public ApiClient()
        {

        }
        public ApiClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<Movie> GetThorMovie()
        {
            var result = await _baseUrl
                .AppendPathSegment("movie")
                .AppendPathSegment("284053")
                .SetQueryParams(_apiKey, "language=en-US")
                .GetStringAsync();
            var movie = JsonConvert.DeserializeObject<Movie>(result);
            return movie;
        }
    }
}
