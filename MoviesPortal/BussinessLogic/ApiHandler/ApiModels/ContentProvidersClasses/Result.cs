using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ApiHandler.ApiModels.ContentProvidersClasses
{
    public class Result
    {
        [JsonProperty("PL")]
        public ProvidersStore PL { get; set; }

        [JsonProperty("US")]
        public ProvidersStore US { get; set; }
    }
}
