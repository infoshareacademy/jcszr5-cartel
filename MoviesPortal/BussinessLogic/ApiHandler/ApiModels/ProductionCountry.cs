using System.Text.Json.Serialization;

namespace BusinessLogic.ApiHandler.ApiModels
{
    public class ProductionCountry
    {
        [JsonPropertyName("iso_3166_1")]
        public string Iso31661 { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}