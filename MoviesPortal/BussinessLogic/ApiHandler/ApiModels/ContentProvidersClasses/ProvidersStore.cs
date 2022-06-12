using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ApiHandler.ApiModels.ContentProvidersClasses
{
    public class ProvidersStore
    {
        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("buy")]
        public List<Provider> Buy { get; set; }

        [JsonProperty("rent")]
        public List<Provider> Rent { get; set; }

        [JsonProperty("flatrate")]
        public List<Provider> Flatrate { get; set; }
    }
}
