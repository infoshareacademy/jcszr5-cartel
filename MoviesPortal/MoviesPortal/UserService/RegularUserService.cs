using MoviesPortal.Data;
using MoviesPortal.Interface;
using MoviesPortal.Menu;
using MoviesPortal.Methods;

namespace MoviesPortal.UserService
{
    public class RegularUserService : IUserReader, IUserWriter
    {
        public void GetUser()
        {
            // Read BD with users accounts from json file
            var database = ReadData.ReadUsersFromFile();
            LoggedUser.WhoIsLogged();

            // Check input user login with DB
            var password = ValidateUser.ValidateUserLogin(database);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"USER LOGIN: no user logged");
            Console.WriteLine("========================================");
            Console.ResetColor();

            // Check input user password with DB
            ValidateUser validateUser = new ValidateUser();
            validateUser.ValidateUserPassword(password);
            LoginTyper.LoginType = "user";
        }

        public void AddUser()
        {
            // Read BD with users accounts from json file
            var database = ReadData.ReadUsersFromFile();
            LoggedUser.WhoIsLogged();

            // Check input user login with DB and if no exist is - create
            string login = ValidateUser.CreateUserLogin(database);
            LoggedUser.WhoIsLogged();

            // Check input user password and if meets the requirements - create
            string password = ValidateUser.CreateUserPassword();            

            // Write to DB new account parameters = id, login and password
            WriteData writeData = new WriteData();
            writeData.WriteUserToFile(login, password);
            LoggedUser.UserName = login;
            LoginTyper.LoginType = "user";
            MenuInitializer.InitializeMenu();
        }
    }
}
