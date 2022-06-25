using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ApiHandler.ApiModels
{
    public class PersonSearchResult
    {
        public int page { get; set; }
        public List<Cast> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
