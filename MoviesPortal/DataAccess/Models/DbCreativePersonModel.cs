using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
        public virtual IList<DbMovieModel> StarredInMovies { get; set; }

        //public DbCreativePersonModel(string name, string surName, DateTime birthDate, CreativeRole role)
        //{
        //    Name = name;
        //    SurName = surName;
        //    DateOfBirth = birthDate;
        //    Role = role;
        //}
    }
}
