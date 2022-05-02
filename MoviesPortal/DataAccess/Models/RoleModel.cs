using DataAccess.Models.EntityAssigments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class RoleModel
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public ICollection<CreativePersonModel> CreativePersons { get; set; }
        public virtual ICollection<RoleCreativeMovie> RoleCreativePersons { get; set; }
    }
}
