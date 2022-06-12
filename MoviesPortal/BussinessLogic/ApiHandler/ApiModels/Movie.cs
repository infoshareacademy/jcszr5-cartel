using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessLogic.ApiHandler.ApiModels
{
    public class Movie
    {
        [JsonPropertyName("adult")]
        public bool Adult { get; set; }

        [JsonPropertyName("backdrop_path")]
        public string Backdrop_Path { get; set; }

        [JsonPropertyName("belongs_to_collection")]
        public BelongsToCollection Belongs_To_Collection { get; set; }

        [JsonPropertyName("budget")]
        public int Budget { get; set; }

        [JsonPropertyName("genres")]
        public List<Genre> Genres { get; set; }

        [JsonPropertyName("homepage")]
        public string Homepage { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("imdb_id")]
        public string Imdb_Id { get; set; }

        [JsonPropertyName("original_language")]
        public string Original_Language { get; set; }

        [JsonPropertyName("original_title")]
        public string Original_Title { get; set; }

        [JsonPropertyName("overview")]
        public string Overview { get; set; }

        [JsonPropertyName("popularity")]
        public double Popularity { get; set; }

        [JsonPropertyName("poster_path")]
        public string Poster_Path { get; set; }

        [JsonPropertyName("production_companies")]
        public List<ProductionCompany> Production_Companies { get; set; }

        [JsonPropertyName("production_countries")]
        public List<ProductionCountry> Production_Countries { get; set; }

        [JsonPropertyName("release_date")]
        public string Release_Date { get; set; }

        [JsonPropertyName("revenue")]
        public int Revenue { get; set; }

        [JsonPropertyName("runtime")]
        public int Runtime { get; set; }        

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("tagline")]
        public string Tagline { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("video")]
        public bool Video { get; set; }

        [JsonPropertyName("vote_average")]
        public double Vote_Average { get; set; }

        [JsonPropertyName("vote_count")]
        public int Vote_Count { get; set; }

        public bool IsApiModel { get; set; } = true;
    }
}
