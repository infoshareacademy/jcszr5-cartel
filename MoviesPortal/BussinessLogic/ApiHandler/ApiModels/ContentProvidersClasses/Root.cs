using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ApiHandler.ApiModels.ContentProvidersClasses
{
    public class Root
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("results")]
        public Result Results { get; set; }
    }
}
