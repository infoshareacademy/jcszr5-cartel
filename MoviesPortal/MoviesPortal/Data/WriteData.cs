//using Newtonsoft.Json;
using System.Text.Json;

namespace MoviesPortal.Data
{
    public class WriteData
    {
        public void WriteUserToFile(int idOld, string login, string password)
        {
            int id = idOld + 1;
            User user = new User(id.ToString(), login, password);
           
            List<User> users = new List<User>();
           
            string jsonFromFile = File.ReadAllText(@"..\..\..\Database\users.json"); //odczytaj plik z istniejącymi już userami i przekonwertuj do stringa

            users = JsonSerializer.Deserialize<List<User>>(jsonFromFile); //deserializuj i zapisz istniejących userów do listy       
            users.Add(user);                                                //aktualizuj listę
            var writeIndentedOption = new JsonSerializerOptions { WriteIndented = true }; //formatuj plik Json
            var json = JsonSerializer.Serialize(users, writeIndentedOption); //serializuj zaktualizowaną listę userów
            // to improve
            File.WriteAllText(@"..\..\..\Database\users.json", json);

            Console.WriteLine($"User: {login} was added to database!");
        }
    }
}
