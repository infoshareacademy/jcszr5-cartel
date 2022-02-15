using MoviesPortal.DataLayer.Models;
using System.Text.Json;

namespace MoviesPortal.Data
{
    public class WriteData
    {
        public void WriteUserToFile(string login, string password)
        {
            User user = new User(login, password);
           
            List<User> users = new List<User>();
           
            string jsonFromFile = File.ReadAllText(@"..\..\..\..\MoviesPortal.DataLayer\Database\users.json"); //odczytaj plik z istniejącymi już userami i przekonwertuj do stringa

            users = JsonSerializer.Deserialize<List<User>>(jsonFromFile); //deserializuj i zapisz istniejących userów do listy       
            users.Add(user);                                                //aktualizuj listę
            var writeIndentedOption = new JsonSerializerOptions { WriteIndented = true }; //formatuj plik Json
            var json = JsonSerializer.Serialize(users, writeIndentedOption); //serializuj zaktualizowaną listę userów
            // to improve
            File.WriteAllText(@"..\..\..\..\MoviesPortal.DataLayer\Database\users.json", json);

            Console.WriteLine($"User: {login} was added to database!");
        }
    }
}
