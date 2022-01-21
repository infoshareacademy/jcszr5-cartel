using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPortal
{
    public class UserMenu
    {
        public List<string> selectionOptions = new List<string>()
        {
            "Browse Movies",
            "Search Movies",
            "For Kids",
            "Exit"
        };

        public List<string> browseOptions = new List<string>()
        {
            "By Title",
            "By Genre",
            "By Actor",
            "Back to menu"
        };

        public List<string> searchOptions = new List<string>()
        {
            "By Title",
            "By Genre",
            "By Actor",
            "Back to menu"
        };

        public void ListMainOptions()
        {
            var index = 1;
            foreach (var option in selectionOptions)
            {
                Console.WriteLine($"{index}. {option}");
            }
        }
        public void ListBrowseOptions()
        {
            var index = 1;
            foreach (var option in browseOptions)
            {
                Console.WriteLine($"{index}. {option}");
            }
        }
        public void ListSearchOptions()
        {
            var index = 1;
            foreach (var option in searchOptions)
            {
                Console.WriteLine($"{index}. {option}");
            }
        }

        public void GetUserChoiceInMainMenu()
        {
            Console.WriteLine("\n Choose option by type correct number:");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                {
                    ListBrowseOptions();
                    break;
                }
                case "2":
                {
                    ListSearchOptions();
                    break;
                }
                case "3":
                {
                    //TODO list films for kids
                    break;
                }
                case "4":
                {
                    Console.WriteLine("Are You sure? (y/n)");
                    string decision = Console.ReadLine();
                    if (decision=="y")
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        GetUserChoiceInMainMenu();
                    }
                    break;
                }
                default:
                {
                    Console.WriteLine("Please type correct number (from 1 to 4)");
                    GetUserChoiceInMainMenu();
                    break;
                }
            }

        }

        public void InitializeUserMenu()
        {
            ListMainOptions();
            GetUserChoiceInMainMenu();
        }
    }
    
}

    
