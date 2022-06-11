using System.Text.Encodings.Web;
using System.Text.Json;
using MoviesPortal.DataLayer.Models;

namespace MoviesPortal.DataLayer
{
    public class CreativePersonAgency
    {
        private static List<CreativePerson> CreativePersonList = new();
        private string creativesPath = Config.creativePersonsDbPath;


        public static void AddCreativePerson(CreativePerson person)
        {
            CreativePersonList.Add(person);
            
        }

        public static void DeletePerson(CreativePerson personToDelete)
        {
            CreativePersonList.Remove(personToDelete);
            Console.WriteLine($"{personToDelete.Role} - {personToDelete.Name}  {personToDelete.SurName}  has been successfully removed");
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
                    Console.WriteLine("List of creative peoples is empty.");
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

        /// <summary>
        /// Saves contents of Creative Person list to Json
        /// </summary>
        public void SaveCreativePersonsListToJson()
        {
            IList<CreativePerson> listToSave = CreativePersonList;
            var writeIndentedOption = new JsonSerializerOptions { WriteIndented = true }; //formatuj plik Json

            var json = JsonSerializer.Serialize(listToSave, writeIndentedOption);
            File.WriteAllText(creativesPath, json);
        }

        /// <summary>
        /// Clears contents of Creative Person List and replaces it with loaded list of creative people from Json
        /// </summary>
        public void LoadCreativePersonsFromJson()
        {
            MovieStore.ClearStoreContent();
            string jsonFromFile = File.ReadAllText(creativesPath);
            CreativePersonList = JsonSerializer.Deserialize<List<CreativePerson>>(jsonFromFile);
            //if (peoplesFromFile.Count > 0)
            //{
            //    foreach (var person in peoplesFromFile)
            //    {
            //        AddCreativePerson(person);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("There is nothing to load");
            //}
        }
    }
}
