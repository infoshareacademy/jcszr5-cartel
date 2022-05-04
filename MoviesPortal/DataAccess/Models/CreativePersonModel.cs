using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataAccess.Models.EntityAssigments;
using DataAccess.Models.Enums;

namespace DataAccess.Models
{
    public class CreativePersonModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string? PhotographyPath { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
              
        public virtual ICollection<RoleCreativeMovie> RoleCreativeMovie { get; set; }
        public virtual ICollection<TvSeries_CreativeP_Role> TvSeries_CreativeP_Role { get; set; }




    }
}
