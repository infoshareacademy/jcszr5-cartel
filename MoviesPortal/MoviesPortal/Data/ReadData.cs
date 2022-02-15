using MoviesPortal.DataLayer.Models;
using System.Text.Json;

namespace MoviesPortal.Data
{
    public class ReadData
    {
        public static List<User> ReadUsersFromFile()
        {
            string jsonFromFile = File.ReadAllText(@"..\..\..\..\MoviesPortal.DataLayer\Database\users.json");
            List<User> Users = JsonSerializer.Deserialize<List<User>>(jsonFromFile);
            //Console.WriteLine("Database successfully loaded!");
            return Users;

        }
        public static List<User> ReadAdminsFromFile()
        {
            string jsonFromFile = File.ReadAllText(@"..\..\..\..\MoviesPortal.DataLayer\Database\admins.json");
            List<User> Users = JsonSerializer.Deserialize<List<User>>(jsonFromFile);
           // Console.WriteLine("Database successfully loaded!");
            return Users;
        }
    }
}
