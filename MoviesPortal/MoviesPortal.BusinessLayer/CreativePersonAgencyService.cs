using MoviesPortal.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPortal.BusinessLayer
{
    public class CreativePersonAgencyService
    {

        public void AddCreativePerson(CreativePerson creativePerson)
        {
            CreativePersonAgency.AddCreativePerson(creativePerson);
        }

        public List<CreativePerson> GetCreativePerson(CreativeRole role)
        {
            return CreativePersonAgency.GetCreativePersonList(role);
        }

    }
}
