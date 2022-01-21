using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPortal
{
    public class LoginPanel
    {
        bool flag;
        public void ChooseOption()
        {
            LoginPanel log = new LoginPanel();
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
                    case ConsoleKey.D1: //Number 1 Key
                        log.LoginToAccount();
                        flag = true;
                        break;
                    case ConsoleKey.D2: //Number 2 Key
                        log.CreateNewAccount();
                        flag = true;
                        break;

                    case ConsoleKey.D3: //Number 3 Key
                        log.LoginToAdminAccount();
                        flag = true;
                        break;

                    case ConsoleKey.D4: //Number 4 Key
                        Console.WriteLine("Goodbye!");
                        flag = true;
                        break;

                    default: //Not known key pressed
                        Console.WriteLine("[!] Wrong key, choose  another one: 1, 2, 3 or 4.");
                        flag = false;
                        break;
                }
            } while (flag == false);
        }

        #region [1]
        public void LoginToAccount()
        {
            // Login base from txt file "Users.txt".
            string[] usersDatabase = File.ReadAllLines(@"D:\KURS\Projekt\jcszr5-cartel\MoviesPortal\MoviesPortal\Database\UsersDatabase.txt");
            string[] user;

            // Create new list containing variables 'userId', 'userName', 'UserPassword' and add to main list "Users"
            List<List<string>> Users = new List<List<string>>();

            string userId;
            string userName;
            string userPassword;

            for (int i = 0; i < usersDatabase.Length; i++)
            {
                user = usersDatabase[i].ToString().Split('/');
                userId = user[0];
                userName = user[1];
                userPassword = user[2];
                Users.Add(new List<string> { userId, userName, userPassword });
            }

            #region Check login
            // Check that input login:
            // - is not null or empty
            // - not contain spaces
            // - not spacial symbol
            // - not only int
            // + lenght min 7, max 15 symbols
            // + string + int

            int checkLogin = 0;
            var correctPassword = "";
            string login = "";
            string password = "";

            string? inputValue; // or var?

            do
            {
                Console.WriteLine(">>> Input your login:");
                inputValue = Console.ReadLine();

                if (inputValue == null)
                {
                    Console.WriteLine("[!] Input value is null, please input correct value.");
                    flag = false;
                }
                else
                {
                    if (MethToCheckInputValue.CheckThatInputLoginMeetTheRequirements(inputValue) == true)
                    {
                        // Verification that input login matches with any login in database
                        foreach (var item in Users)
                        {
                            if (inputValue == item[1])
                            {
                                correctPassword = item[2];
                                login = inputValue;
                                checkLogin = 1;
                                flag = true;
                                break;
                            }
                        }

                        if (checkLogin == 0)
                        {
                            Console.WriteLine($"Input login '{inputValue}' not matche with that in database. Try again.");
                        }

                    }
                    else
                    {
                        flag = false;
                    }
                }

            } while (flag == false);
            #endregion

            #region Check password

            Console.WriteLine($"Input login '{inputValue}' matches with that in database.");

            // Check that input password:
            // + lenght min 8, max 20 symbols
            // + contains min one upper letter and one lower letter
            // + contains min 2 digits
            // + contains min 4 letters
            // + contains min 1 special char
            // - is not null or empty
            // - not contain spaces
            // - not only int

            do
            {
                Console.WriteLine(">>> Input your password:");
                inputValue = Console.ReadLine();

                if (inputValue == null)
                {
                    Console.WriteLine("[!] Input value is null, please input correct value.");
                    flag = false;
                }
                else
                {
                    if (MethToCheckInputValue.CheckThatInputPasswordMeetTheRequirements(inputValue) == true)
                    {
                        // Verification that input password matches with password in database for out login
                        if (correctPassword == inputValue)
                        {
                            Console.WriteLine($"Input password '{inputValue}' match with '{correctPassword}'");
                            flag = true;
                            password = inputValue;
                        }
                        else
                        {
                            Console.WriteLine($"Input password '{inputValue}' not matche with that in database. Try again.");
                            flag = false;
                        }
                    }
                    else
                    {
                        flag = false;
                    }
                }


            } while (flag == false);


            #endregion

            Console.WriteLine($"Congratulation! You login to your account.");

        }
        #endregion

        #region [2]
        public void CreateNewAccount() 
        {
            // Check that new login:
            // - is not null or empty
            // - not contain spaces
            // - not spacial symbol
            // - not only int
            // + lenght min 7, max 15 symbols
            // + string + int

            // Login base from txt file "Users.txt".
            string[] usersDatabase = File.ReadAllLines(@"D:\KURS\Projekt\jcszr5-cartel\MoviesPortal\MoviesPortal\Database\UsersDatabase.txt");
            string[] user;

            // Create new list containing variables 'userId', 'userName', 'UserPassword' and add to main list "Users"
            List<List<string>> Users = new List<List<string>>();

            string userId;
            string userName;
            string userPassword;
            int lastIdNumber = 0;

            for (int i = 0; i < usersDatabase.Length; i++)
            {
                user = usersDatabase[i].ToString().Split('/');
                userId = user[0];
                userName = user[1];
                userPassword = user[2];
                Users.Add(new List<string> { userId, userName, userPassword });

                if (i == usersDatabase.Length - 1)
                {
                    lastIdNumber = Convert.ToInt32(userId) + 1;
                }
            }

            int checkLogin = 0;
            string login = "";
            string password = "";
            string? inputValue; // or var?

            #region Create new account
            do
            {
                Console.WriteLine(">>> Create your new login!\n(if you type 'help' you will see the rules with should contains your login).");
                inputValue = Console.ReadLine();

                if (inputValue == "help")
                {
                    Console.WriteLine("Your new login should:\n+ min 5 letters,\n+ lenght min 7, max 15 symbols,\n+ can contains stings and integers,\n- no spaces," +
                        "\n- no special symbols,\n- no only integers.\nPress any button to back to login creator");
                    Console.ReadKey();
                    flag = false;
                }
                else if (inputValue == null)
                {
                    Console.WriteLine("[!] Input value is null, please input correct value.");
                    flag = false;
                }
                else
                {
                    if (MethToCheckInputValue.CheckThatInputLoginMeetTheRequirements(inputValue) == true)
                    {
                        // Verification that input login matches with any login in database
                        foreach (var item in Users)
                        {
                            if (inputValue == item[1])
                            {
                                Console.WriteLine($"Input login '{inputValue}' matche with some in database. Try Again.");
                                checkLogin = 1;
                                flag = false;
                                break;
                            }
                        }

                        if (checkLogin == 0)
                        {
                            Console.WriteLine($"Input login '{inputValue}' not exist in database. Now create your password.");
                            login = inputValue;
                            flag = true;
                        }

                    }
                    else
                    {
                        flag = false;
                    }


                }

            } while (flag == false);
            #endregion

            #region Create password

            // Check that input password:
            // + lenght min 8, max 20 symbols
            // + contains min one upper letter and one lower letter
            // + contains min 2 digits
            // + contains min 4 letters
            // + contains min 1 special char
            // - is not null or empty
            // - not contain spaces
            // - not only int

            do
            {
                Console.WriteLine(">>> Create your password!\n(if you type 'help' you will see the rules with should contains your login).");
                inputValue = Console.ReadLine();

                if (inputValue == "help")
                {
                    Console.WriteLine("Your password should:\n+ min 4 letters,\n+ lenght min 8, max 20 symbols,\n+ min 2 digits,\n+ min 1 special symbol\n+ min 1 upper and lower letter,\n- no spaces," +
                       "\n- no only integers.\nPress any button to back to password creator");
                    Console.ReadKey();
                    flag = false;
                }
                else if (inputValue == null)
                {
                    Console.WriteLine("[!] Input value is null, please input correct value.");
                    flag = false;
                }
                else
                {
                    if (MethToCheckInputValue.CheckThatInputPasswordMeetTheRequirements(inputValue) == true)
                    {

                        Console.WriteLine($"Input password '{inputValue}' meets all requirements");
                        password = inputValue;
                        flag = true;

                    }
                    else
                    {
                        flag = false;
                    }
                }


            } while (flag == false);


            Console.WriteLine($"Congratulation, your created new account!\nYour login: {login}\nYour password: {password}\nWrite them down in a safe place!");

            #endregion

            #region Save login and password to database

            string insert = $"{lastIdNumber}/{login}/{password}";
            File.AppendAllText(@"D:\KURS\Projekt\jcszr5-cartel\MoviesPortal\MoviesPortal\Database\UsersDatabase.txt", Environment.NewLine + insert);
            Console.WriteLine("New account was added to database!");

            #endregion

        }
        #endregion

        #region [3]
        public void LoginToAdminAccount()
        {
            // Login base from txt file "Users.txt".
            string[] usersDatabase = File.ReadAllLines(@"D:\KURS\Projekt\jcszr5-cartel\MoviesPortal\MoviesPortal\Database\AdminDatabase.txt");
            string[] user;

            // Create new list containing variables 'userId', 'userName', 'UserPassword' and add to main list "Users"
            List<List<string>> Users = new List<List<string>>();

            string userId;
            string userName;
            string userPassword;

            for (int i = 0; i < usersDatabase.Length; i++)
            {
                user = usersDatabase[i].ToString().Split('/');
                userId = user[0];
                userName = user[1];
                userPassword = user[2];
                Users.Add(new List<string> { userId, userName, userPassword });
            }

            #region Check admin login
            // Check that input login:
            // - is not null or empty
            // - not contain spaces
            // - not spacial symbol
            // - not only int
            // + lenght min 7, max 15 symbols
            // + string + int

            int checkLogin = 0;
            var correctPassword = "";
            string login = "";
            string password = "";

            string? inputValue; // or var?

            do
            {
                Console.WriteLine(">>> Input your admin login:");
                inputValue = Console.ReadLine();

                if (inputValue == null)
                {
                    Console.WriteLine("[!] Input value is null, please input correct value.");
                    flag = false;
                }
                else
                {
                    if (MethToCheckInputValue.CheckThatInputLoginMeetTheRequirements(inputValue) == true)
                    {
                        // Verification that input login matches with any login in database
                        foreach (var item in Users)
                        {
                            if (inputValue == item[1])
                            {
                                correctPassword = item[2];
                                login = inputValue;
                                checkLogin = 1;
                                flag = true;
                                break;
                            }
                        }

                        if (checkLogin == 0)
                        {
                            Console.WriteLine($"Input admin login '{inputValue}' not matche with that in database. Try again.");
                        }

                    }
                    else
                    {
                        flag = false;
                    }


                }

            } while (flag == false);

            Console.WriteLine($"Input admin login '{inputValue}' matches with that in database.");

            #endregion

            #region Check password

            // Check that input password:
            // + lenght min 8, max 20 symbols
            // + contains min one upper letter and one lower letter
            // + contains min 2 digits
            // + contains min 4 letters
            // + contains min 1 special char
            // - is not null or empty
            // - not contain spaces
            // - not only int

            do
            {
                Console.WriteLine(">>> Input your password:");
                inputValue = Console.ReadLine();

                if (inputValue == null)
                {
                    Console.WriteLine("[!] Input value is null, please input correct value.");
                    flag = false;
                }
                else
                {
                    if (MethToCheckInputValue.CheckThatInputPasswordMeetTheRequirements(inputValue) == true)
                    {
                        // Verification that input password matches with any login in database
                        if (correctPassword == inputValue)
                        {
                            Console.WriteLine($"Input password {inputValue} match with {correctPassword}");
                            flag = true;
                            password = inputValue;
                        }
                        else
                        {
                            Console.WriteLine($"Input password '{inputValue}' not matche with that in database. Try again.");
                            flag = false;
                        }
                    }
                    else
                    {
                        flag = false;
                    }
                }


            } while (flag == false);


            #endregion

            Console.WriteLine($"Congratulation! You login to your admin account.");

        }
        #endregion

    }
}