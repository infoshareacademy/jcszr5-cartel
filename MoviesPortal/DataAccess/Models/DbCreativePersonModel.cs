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
    public class DbCreativePersonModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        public CreativeRole Role { get; set; }
        public virtual ICollection<DbMovieModel> Movies { get; set; }
        public virtual ICollection<MovieCreativePerson> MovieCreativePersons { get; set; }


        
    }
}
