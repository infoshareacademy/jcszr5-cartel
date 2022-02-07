using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPortal.DataLayer.Models
{
    public class Actor : Person
    {
        public Actor(string name, string surName) : base(name, surName)
        {
        }
    }
}
