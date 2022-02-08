

namespace MoviesPortal.DataLayer
{
    public class CreativePersonAgency
    {
        private static List<CreativePerson> CreativePersonList = new();


        public static void AddCreativePerson(CreativePerson person)
        {
            CreativePersonList.Add(person);
        }


        public  static List<CreativePerson> GetCreativePersonList(CreativeRole role)
        {
            List<CreativePerson> creativePerson = new();

            foreach (CreativePerson person in CreativePersonList)
            {
                if (person == null)
                {
                    Console.WriteLine("There's no person in database.");
                    break;
                }
                else if (person.Role == role)
                {
                    creativePerson.Add(person);
                    continue;
                }
                else
                {
                    continue;
                }
            }
            return creativePerson;
        }
    }
}
