using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ApiHandler.ApiModels
{
    public class Rating
    {
        [JsonProperty("Source")]
        public string Source { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }
    }
}
