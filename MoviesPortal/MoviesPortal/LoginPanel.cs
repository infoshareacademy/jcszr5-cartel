using MoviesPortal.Interface;
using MoviesPortal.UserService;

namespace MoviesPortal
{
    public class LoginPanel
    {
        public void ChooseOption()
        {
            bool isChoosed;
            do
            {
                Console.WriteLine("Welcome in the login panel!" +
                        "\nSelect one of the numbers below to proceed:" +
                        "\n [1] - log in to your account," +
                        "\n [2] - create new account," +
                        "\n [3] - log in as admi," +
                        "\n [4] - turn off the application.");

                ConsoleKeyInfo keyReaded = Console.ReadKey();
                Console.ReadKey();
                Console.WriteLine("");
                switch (keyReaded.Key)
                {
                    case ConsoleKey.D1: // Load to user account
                        IUserReader regularUserReader = new RegularUserService();
                        regularUserReader.GetUser();
                        isChoosed = true;
                        break;
                    case ConsoleKey.D2: // Create new user account
                        IUserWriter regularUserWrite = new RegularUserService();
                        regularUserWrite.AddUser();
                        isChoosed = true;
                        ChooseOption();
                        break;

                    case ConsoleKey.D3: // Load to admin account
                        IUserReader adminReader = new AdminUserService();
                        adminReader.GetUser();
                        isChoosed = true;
                        break;

                    case ConsoleKey.D4: // Close app
                        Console.WriteLine("Goodbye!");
                        isChoosed = true;
                        break;

                    default: //Not known key pressed
                        Console.WriteLine("[!] Wrong key, choose  another one: 1, 2, 3 or 4.");
                        isChoosed = false;
                        break;
                }
            } while (isChoosed == false);
        }
    }
}