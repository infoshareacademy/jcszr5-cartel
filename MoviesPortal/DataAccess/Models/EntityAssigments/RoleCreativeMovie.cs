using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.EntityAssigments
{
    public class RoleCreativeMovie
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int CreativePersonId { get; set; }
        public int MovieId { get; set; }
        public RoleModel Role { get; set; }
        public CreativePersonModel CreativePerson { get; set; }
        public MovieModel Movie { get; set; }

    }
}
