

namespace MoviesPortal.DataLayer
{
    public class CreativePersonAgency
    {
        private static List<CreativePerson> CreativePersonList = new();


        public static void AddCreativePerson(CreativePerson person)
        {
            CreativePersonList.Add(person);
        }

        public static void DeletePerson(CreativePerson personToDelate)
        {
            CreativePersonList.Remove(personToDelate);
            Console.WriteLine($"{personToDelate.Role} - {personToDelate.Name}  {personToDelate.SurName}  has been sucessfully removed");
            Thread.Sleep(2000);
            Console.Clear();
        }



        public  static List<CreativePerson> GetCreativePersonsList(CreativeRole role)
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
