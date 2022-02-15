using MoviesPortal.Data;
using MoviesPortal.Interface;
using MoviesPortal.Methods;

namespace MoviesPortal.UserService
{
    public class AdminUserService : IUserReader
    {
        public void GetUser()
        {
            // Read BD with admins accounts from json file
            var database = ReadData.ReadAdminsFromFile();
            LoggedUser.WhoIsLogged();

            // Check input admin login with DB
            var password = ValidateUser.ValidateUserLogin(database);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"USER LOGIN: no user logged");
            Console.WriteLine("========================================");
            Console.ResetColor();

            // Check input admin password with DB
            ValidateUser validateUser = new ValidateUser();
            validateUser.ValidateUserPassword(password);
            LoginTyper.LoginType = "admin";
        }
    }
}
