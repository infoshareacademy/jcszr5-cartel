using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MoviesPortal.Menu;

namespace MoviesPortal
{
    public class UserMenu : IMenu
    {

        public List<string> SelectionOptions
        {
            get
            {
                return new List<string>() {
                    "Browse Movies",
                    "Search Movies",
                    "For Kids",
                    "Exit" };
            }
        }


        // public List<string> selectionOptions = new List<string>()
        // {
        //     "Browse Movies",
        //     "Search Movies",
        //     "For Kids",
        //     "Exit"
        // };

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
            foreach (var option in SelectionOptions)
            {
                Console.WriteLine($"{index}. {option}");
                index++;
            }
        }
        public void ListBrowseOptions()
        {
            var index = 1;
            foreach (var option in browseOptions)
            {
                Console.WriteLine($"{index}. {option}");
                index++;
            }
        }
        public void ListSearchOptions()
        {
            var index = 1;
            foreach (var option in searchOptions)
            {
                Console.WriteLine($"{index}. {option}"); 
                index++;
            }
        }

        public void GetUserChoiceInBrowseMenu()
        {
            Console.WriteLine("\n Choose option by type correct number:");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                {
                    //list films by title
                    Console.WriteLine("your movies will be here, sorted by title");
                    break;
                }
                case "2":
                {
                    //list films by genre
                    Console.WriteLine("your movies will be here, sorted by genre");
                    break;
                    }
                case "3":
                {
                    //list films by actor
                    Console.WriteLine("your movies will be here, sorted by actor");
                    break;
                    }
                case "4"://back to main menu
                {
                    InitializeMenu();
                    break;
                }
                default:
                {
                    Console.WriteLine("Please type correct number (from 1 to 4)");
                    GetUserChoiceInBrowseMenu();
                    break;
                }
            }

        }
        public void GetUserChoiceInSearchMenu()
        {
            Console.WriteLine("\n Choose option by type correct number:");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                {
                    //search films by title
                    Console.WriteLine("Tutaj będzie wyszukiwarka");
                    break;
                }
                case "2":
                {
                    //search films by genre
                    Console.WriteLine("Tutaj będzie wyszukiwarka");
                    break;
                }
                case "3":
                {
                    //search films by actor
                    Console.WriteLine("Tutaj będzie wyszukiwarka");
                    break;
                }
                case "4"://back to main menu
                {
                    InitializeMenu();
                    break;
                }
                default:
                {
                    Console.WriteLine("Please type correct number (from 1 to 4)");
                    GetUserChoiceInSearchMenu();
                    break;
                }
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
                    GetUserChoiceInBrowseMenu();
                    break;
                }
                case "2":
                {
                    ListSearchOptions();
                    GetUserChoiceInSearchMenu();
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
                        InitializeMenu();
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

        public void InitializeMenu() 
        {
            ListMainOptions();
            GetUserChoiceInMainMenu();
        }
    }
    
}

    
