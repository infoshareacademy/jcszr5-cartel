using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataAccess.Models.Enums;

namespace DataAccess.Models
{
    internal class DbCreativePersonModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public CreativeRole Role { get; set; }

        public DbCreativePersonModel(string name, string surName, DateTime birthDate, CreativeRole role)
        {
            Name = name;
            SurName = surName;
            DateOfBirth = birthDate;
            Role = role;
        }
    }
}
