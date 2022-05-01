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
        public virtual ICollection<MovieModel> Movies { get; set; }
        public virtual ICollection<MovieCreativePerson> MovieCreativePersons { get; set; }
        public virtual ICollection<TvSeriesModel> TvSeries { get; set; }
        public virtual ICollection<TvSeriesCreativePerson> TvSeriesCreativePersons { get; set; }
        public virtual ICollection<RoleModel> Roles { get; set; }
        public virtual ICollection<RoleCreativeMovie> RoleCreativePersons { get; set; }




    }
}
