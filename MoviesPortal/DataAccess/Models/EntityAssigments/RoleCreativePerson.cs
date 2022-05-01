using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.EntityAssigments
{
    public class RoleCreativePerson
    {
        public int RoleId { get; set; }
        public int CreativePersonId { get; set; }
        public RoleModel Role { get; set; }
        public CreativePersonModel CreativePerson { get; set; }

    }
}
