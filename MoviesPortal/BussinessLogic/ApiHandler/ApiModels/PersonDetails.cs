using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ApiHandler.ApiModels
{
    public class PersonDetails
    {             

        [JsonProperty("biography")]
        public string Biography { get; set; }

        [JsonProperty("birthday")]
        public string Birthday { get; set; }

        [JsonProperty("deathday")]
        public object Deathday { get; set; }

        [JsonProperty("gender")]
        public int Gender { get; set; }

        [JsonProperty("homepage")]
        public object Homepage { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("imdb_id")]
        public string ImdbId { get; set; }        

        [JsonProperty("name")]
        public string Name { get; set; }        

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("profile_path")]
        public string Profile_Path { get; set; }
        public bool IsApiModel { get; set; } = true;
    }
}
