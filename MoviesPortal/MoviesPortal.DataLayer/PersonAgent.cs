using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPortal.DataLayer
{
    public class PersonAgent
    {
        static List<Person> _persons = new List<Person>();

        public static void AddPerson(Person newPerson)
        {
            _persons.Add(newPerson);
        }
    }
}
