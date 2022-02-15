using MoviesPortal.Data;
using MoviesPortal.Interface;
using MoviesPortal.Menu;
using MoviesPortal.UserService;

namespace MoviesPortal
{
    public class LoginPanel
    {
        public static void MainPanel()
        {
            if (LoggedUser.UserName == "no user logged")
            {
                MainPanelToLogIn();
                MenuInitializer.InitializeMenu();
            }
            else
            {
                MainPanelToLogOut();
            }

        }
        
        public static void MainPanelToLogIn()
        {
            List<string> OptionsList = new List<string> { ">> Log in to your account", ">> Create new account", ">> Log in as admi", ">> Turn off the application" };

            int currentLine = 0;
            int counter;
            ConsoleKeyInfo key;
            while (true)
            {
                Console.Clear();
                ShowLogo();               
                for (counter = 0; counter < OptionsList.Count; counter++)
                {
                    if (currentLine == counter)
                    {
                        Console.WriteLine($"{OptionsList[counter]}", Console.BackgroundColor = ConsoleColor.White, Console.ForegroundColor = ConsoleColor.Black);
                    }
                    else
                    {
                        Console.WriteLine($"{OptionsList[counter]}", Console.BackgroundColor = ConsoleColor.Black, Console.ForegroundColor = ConsoleColor.White);
                    }
                }
                
                Console.WriteLine("", Console.BackgroundColor = ConsoleColor.Black, Console.ForegroundColor = ConsoleColor.White);

                key = Console.ReadKey(true);

                if (key.Key.ToString() == "DownArrow")
                {
                    currentLine++;
                    if (currentLine > OptionsList.Count - 1) currentLine = 0;
                }
                else if (key.Key.ToString() == "UpArrow")
                {
                    currentLine--;
                    if (currentLine < 0) currentLine = OptionsList.Count - 1;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    switch (currentLine)
                    {
                        case 0: // Load to user account
                            IUserReader regularUserReader = new RegularUserService();
                            regularUserReader.GetUser();
                            break;
                        case 1: // Create new user account
                            IUserWriter regularUserWrite = new RegularUserService();
                            regularUserWrite.AddUser();
                            MainPanel();
                            break;
                        case 2: // Load to admin account
                            IUserReader adminReader = new AdminUserService();
                            adminReader.GetUser();
                            break;
                        case 3: // Close app
                            Console.WriteLine("Goodbye!");
                            Environment.Exit(0);
                            break;

                        default:
                            break;
                    }
                    break;
                }
            }
        }

        public static void MainPanelToLogOut()
        {
            List<string> OptionsList = new List<string> { ">> Log out from you account", ">> Turn off the application" };

            int currentLine = 0;
            int counter;
            ConsoleKeyInfo key;
            while (true)
            {
                Console.Clear();
                ShowLogo();
                for (counter = 0; counter < OptionsList.Count; counter++) //list all movies, but format selected line by arrows
                {
                    if (currentLine == counter) //selected line
                    {
                        Console.WriteLine($"{OptionsList[counter]}", Console.BackgroundColor = ConsoleColor.White, Console.ForegroundColor = ConsoleColor.Black);
                    }
                    else //other lines
                    {
                        Console.WriteLine($"{OptionsList[counter]}", Console.BackgroundColor = ConsoleColor.Black, Console.ForegroundColor = ConsoleColor.White);
                    }
                }

                Console.WriteLine("", Console.BackgroundColor = ConsoleColor.Black, Console.ForegroundColor = ConsoleColor.White);

                key = Console.ReadKey(true);

                if (key.Key.ToString() == "DownArrow")
                {
                    currentLine++;
                    if (currentLine > OptionsList.Count - 1) currentLine = 0;
                }
                else if (key.Key.ToString() == "UpArrow")
                {
                    currentLine--;
                    if (currentLine < 0) currentLine = OptionsList.Count - 1;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    switch (currentLine)
                    {
                        case 0: // Logout
                            LoggedUser.UserName = "no user logged";
                            MainPanel();
                            break;
                            
                        case 1: // Close app
                            Console.WriteLine("Goodbye!");
                            Environment.Exit(0);
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        public static void ShowLogo()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("  __  __  ______      _______ ______  _____   _____   ____  _____ _______       _      ");
            Console.WriteLine(" |  \\/  |/ __ \\ \\    / /_   _|  ____|/ ____| |  __ \\ / __ \\|  __ \\__   __|/\\   | |     ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" | \\  / | |  | \\ \\  / /  | | | |__  | (___   | |__) | |  | | |__) | | |  /  \\  | |     ");
            Console.WriteLine(" | |\\/| | |  | |\\ \\/ /   | | |  __|  \\___ \\  |  ___/| |  | |  _  /  | | / /\\ \\ | |     ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(" | |  | | |__| | \\  /   _| |_| |____ ____) | | |    | |__| | | \\ \\  | |/ ____ \\| |____ ");
            Console.WriteLine(" |_|  |_|\\____/   \\/   |_____|______|_____/  |_|     \\____/|_|  \\_\\ |_/_/    \\_\\______|");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("=======================================================================================");
            Console.WriteLine($"USER LOGIN: {LoggedUser.UserName}");
            Console.WriteLine("=======================================================================================");
            Console.ResetColor();            
        }       

    }
}