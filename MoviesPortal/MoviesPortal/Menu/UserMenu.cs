using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MoviesPortal.DataLayer;
using MoviesPortal.Menu;
using MoviesPortal.BusinessLayer.SearchEngine;
using MoviesPortal.DataLayer;

namespace MoviesPortal
{
    public class UserMenu : IMenu
    {
        IOHelper _iOHelper = new();
        ProgramService _programService = new(); 

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
            Console.WriteLine("\n========================================");
            var index = 1;
            foreach (var option in SelectionOptions)
            {
                Console.WriteLine($"{index}. {option}");
                index++;
            }
            Console.WriteLine("\n========================================");
        }
        public void ListBrowseOptions()
        {
            Console.WriteLine("\n========================================");
            var index = 1;
            foreach (var option in browseOptions)
            {
                Console.WriteLine($"{index}. {option}");
                index++;
            }
            Console.WriteLine("\n========================================");
        }
        public void ListSearchOptions()
        {
            Console.WriteLine("\n========================================");
            var index = 1;
            foreach (var option in searchOptions)
            {
                Console.WriteLine($"{index}. {option}"); 
                index++;
            }
            Console.WriteLine("\n========================================");
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
                    Genre userChoiceGenre = _iOHelper.GetMovieGenre("Chose movie genre you are looking for: ");
                    _programService.PrintMoviesByGenre(userChoiceGenre);
                        Thread.Sleep(1500);
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
            IOHelper iOHelper = new();
            
            Console.WriteLine("\n Choose option by type correct number:");
            string choice = Console.ReadLine();            
            switch (choice)
            {
                case "1":
                {
                        ByTitle byTitle = new ByTitle();
                        var searchResults = byTitle.Search(iOHelper.GetStringFromUser("What are You looking for? Type below:"));
                        byTitle.PrintMovies(searchResults);
                    break;
                }
                case "2":
                {
                        ByGenre byGenre = new ByGenre();
                        var searchResults = byGenre.Search(iOHelper.GetStringFromUser("What are You looking for? Type below:"));
                        byGenre.PrintMovies(searchResults);
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
            Console.Clear();
            ListSearchOptions();
            GetUserChoiceInSearchMenu();

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
                case "4": //exit option
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

    
