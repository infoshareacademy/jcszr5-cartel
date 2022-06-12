using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ApiHandler.ApiModels.ContentProvidersClasses
{
    public class Provider
    {
        [JsonProperty("display_priority")]
        public int Display_Priority { get; set; }

        [JsonProperty("logo_path")]
        public string Logo_Path { get; set; }

        [JsonProperty("provider_id")]
        public int Provider_Id { get; set; }

        [JsonProperty("provider_name")]
        public string Provider_Name { get; set; }
    }
}
