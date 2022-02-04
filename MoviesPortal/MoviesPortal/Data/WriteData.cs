using Newtonsoft.Json;

namespace MoviesPortal.Data
{
    public class WriteData
    {
        public void WriteUserToFile(int idOld, string login, string password)
        {
            int id = idOld + 1;
            User user = new User(id.ToString(), login, password);
            List<User> users = new List<User>();
            users.Add(user);

            var json = JsonConvert.SerializeObject(user, Formatting.Indented);
            // to improve
            File.AppendAllText(@"..\..\..\Database\usersNEW.json", Environment.NewLine + json);

            Console.WriteLine($"User: {login} was added to database!");
        }
    }
}
