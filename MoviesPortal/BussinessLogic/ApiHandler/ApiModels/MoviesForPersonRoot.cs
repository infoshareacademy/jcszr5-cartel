using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ApiHandler.ApiModels
{
    public class MoviesForPersonRoot
    {
        [JsonProperty("cast")]
        public List<Movie> Cast { get; set; }

        [JsonProperty("crew")]
        public List<Movie> Crew { get; set; }
    }
}
