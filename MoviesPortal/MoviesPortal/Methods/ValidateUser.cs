namespace MoviesPortal.Methods
{
    public class ValidateUser
    {
        public static string ValidateUserLogin(List<User> Users)
        {
            bool isMatch = false;
            string input;
            string password = "";

            do
            {
                Console.WriteLine(">>> Input your login:");
                input = Console.ReadLine();

                if (CheckInputValue.CheckInputLogin(input))
                {
                    foreach (var item in Users)
                    {
                        if (input == item.Name)
                        {
                            Console.WriteLine($"[+] Inputted login matches with that in database.");
                            password = item.Password;
                            isMatch = true;
                            break;
                        }
                    }

                    if (isMatch != true)
                    {
                        Console.WriteLine($"[!] Inputted login no matches with that in database. Try again.");
                    }
                }

            } while (!isMatch);

            return password;
        }

        public void ValidateUserPassword(string password)
        {
            bool isMatch = false;
            string input;
            do
            {
                Console.WriteLine(">>> Input your password:");
                input = Console.ReadLine();

                if (CheckInputValue.CheckInputPassword(input))
                {
                    if (password == input)
                    {
                        Console.WriteLine($"[+] Inputted password matches with that in database.");
                        isMatch = true;

                    }
                    else
                    {
                        Console.WriteLine($"[!] Inputted password no matches with that in database. Try again.");
                        isMatch = false;
                    }

                }

            } while (!isMatch);

        }

        public static string CreateUserLogin(List<User> Users)
        {
            bool isMatch = false;
            string input;

            do
            {
                Console.WriteLine(">>> Create your new login!\n(if you type 'help' you will see the rules with should contains your login).");
                input = Console.ReadLine();

                if (input == "help")
                {
                    Console.WriteLine("Your new login should:\n+ min 5 letters,\n+ lenght min 7, max 15 symbols,\n+ can contains stings and integers,\n- no spaces," +
                        "\n- no special symbols,\n- no only integers.\nPress any button to back to login creator");
                    Console.ReadKey();
                    isMatch = true;

                }
                else if (CheckInputValue.CheckInputLogin(input))
                {
                    // Verification that input login matches with any login in database
                    foreach (var item in Users)
                    {
                        if (input == item.Name)
                        {
                            Console.WriteLine($"[!] Inputted login matches with that in database. Try Again.");
                            isMatch = true;
                            break;
                        }
                    }

                    if (isMatch == false)
                    {
                        Console.WriteLine($"[+] Inputted login no matches with that in database. Now create your password.");
                        isMatch = false;
                    }
                }
                else
                {
                    isMatch = true;
                }

            } while (isMatch);

            return input;

        }

        public static string CreateUserPassword()
        {

            bool isMatch = false;
            string input;
            string password = "";

            do
            {
                Console.WriteLine(">>> Create your password!\n(if you type 'help' you will see the rules with should contains your login).");
                input = Console.ReadLine();

                if (input == "help")
                {
                    Console.WriteLine("Your password should:\n+ min 4 letters,\n+ lenght min 8, max 20 symbols,\n+ min 2 digits,\n+ min 1 special symbol\n+ min 1 upper and lower letter,\n- no spaces," +
                       "\n- no only integers.\nPress any button to back to password creator");
                    Console.ReadKey();
                    isMatch = true;
                }
                else if (CheckInputValue.CheckInputPassword(input) == true)
                {

                    Console.WriteLine($"[+] Inputted password meets all requirements.");
                    password = input;
                    isMatch = false;

                }
                else
                {
                    isMatch = true;
                }

            } while (isMatch);

            return password;
        }
    }
}
