using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ApiHandler.ApiModels
{
    public class RatingRoot
    {
        [JsonProperty("Ratings")]
        public List<Rating> Ratings { get; set; }
    }
}
