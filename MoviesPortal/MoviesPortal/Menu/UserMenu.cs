using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MoviesPortal.Data;
using MoviesPortal.DataLayer.Models;
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
                    ">> Browse Movies",
                    ">> Search Movies",
                    ">> For Kids",
                    ">> Back to main menu" };
            }
        }

        public List<string> browseOptions = new List<string>()
        {
            ">> By Title",
            ">> By Genre",
            ">> By Actor",
            ">> Back to menu"
        };

        public List<string> searchOptions = new List<string>()
        {
            ">> By Title",
            ">> By Genre",
            ">> By Actor",
            ">> Back to menu"
        };

        public void ListMainOptions()
        {
            Console.WriteLine("========================================");
            var index = 1;
            foreach (var option in SelectionOptions)
            {
                Console.WriteLine($"{index}. {option}");
                index++;
            }
            Console.WriteLine("========================================");
        }
        public void ListBrowseOptions()
        {
            Console.WriteLine("========================================");
            var index = 1;
            foreach (var option in browseOptions)
            {
                Console.WriteLine($"{index}. {option}");
                index++;
            }
            Console.WriteLine("========================================");
        }
        public void ListSearchOptions()
        {
            Console.WriteLine("========================================");
            var index = 1;
            foreach (var option in searchOptions)
            {
                Console.WriteLine($"{index}. {option}");
                index++;
            }
            Console.WriteLine("========================================");
        }
        public void GetUserChoiceInBrowseMenu()
        {
            int currentLine = 0;
            int counter;
            ConsoleKeyInfo key;
            while (true)
            {

                LoggedUser.WhoIsLogged();
                Console.WriteLine("Choose option by type correct number:");
                for (counter = 0; counter < browseOptions.Count; counter++) //list all movies, but format selected line by arrows
                {
                    if (currentLine == counter)
                    {
                        Console.WriteLine($"{browseOptions[counter]}", Console.BackgroundColor = ConsoleColor.White, Console.ForegroundColor = ConsoleColor.Black);
                    }
                    else //other lines
                    {
                        Console.WriteLine($"{browseOptions[counter]}", Console.BackgroundColor = ConsoleColor.Black, Console.ForegroundColor = ConsoleColor.White);
                    }
                }

                Console.WriteLine("", Console.BackgroundColor = ConsoleColor.Black, Console.ForegroundColor = ConsoleColor.White);

                key = Console.ReadKey(true);

                if (key.Key.ToString() == "DownArrow")
                {
                    currentLine++;
                    if (currentLine > browseOptions.Count - 1) currentLine = 0;
                }
                else if (key.Key.ToString() == "UpArrow")
                {
                    currentLine--;
                    if (currentLine < 0) currentLine = browseOptions.Count - 1;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    switch (currentLine)
                    {
                        case 0:
                            {
                                //list films by title
                                Console.WriteLine("your movies will be here, sorted by title");
                                break;
                            }
                        case 1:
                            {
                                //list films by genre
                                Console.WriteLine("your movies will be here, sorted by genre");
                                break;
                            }
                        case 2:
                            {
                                //list films by actor
                                Console.WriteLine("your movies will be here, sorted by actor");
                                break;
                            }
                        case 3://back to main menu
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
            }
        }
        public void GetUserChoiceInSearchMenu()
        {


            int currentLine = 0;
            int counter;
            ConsoleKeyInfo key;
            while (true)
            {

                LoggedUser.WhoIsLogged();
                Console.WriteLine("Choose option by type correct number:");
                for (counter = 0; counter < searchOptions.Count; counter++) //list all movies, but format selected line by arrows
                {
                    if (currentLine == counter)
                    {
                        Console.WriteLine($"{searchOptions[counter]}", Console.BackgroundColor = ConsoleColor.White, Console.ForegroundColor = ConsoleColor.Black);
                    }
                    else //other lines
                    {
                        Console.WriteLine($"{searchOptions[counter]}", Console.BackgroundColor = ConsoleColor.Black, Console.ForegroundColor = ConsoleColor.White);
                    }
                }

                Console.WriteLine("", Console.BackgroundColor = ConsoleColor.Black, Console.ForegroundColor = ConsoleColor.White);

                key = Console.ReadKey(true);

                if (key.Key.ToString() == "DownArrow")
                {
                    currentLine++;
                    if (currentLine > searchOptions.Count - 1) currentLine = 0;
                }
                else if (key.Key.ToString() == "UpArrow")
                {
                    currentLine--;
                    if (currentLine < 0) currentLine = searchOptions.Count - 1;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    switch (currentLine)
                    {
                        case 0:
                            {
                                //search films by title
                                Console.WriteLine("Tutaj będzie wyszukiwarka");
                                break;
                            }
                        case 1:
                            {
                                //search films by genre
                                Console.WriteLine("Tutaj będzie wyszukiwarka");
                                break;
                            }
                        case 2:
                            {
                                //search films by actor
                                Console.WriteLine("Tutaj będzie wyszukiwarka");
                                break;
                            }
                        case 3://back to main menu
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
            }
        }
        public void GetUserChoiceInMainMenu()
        {           
            int currentLine = 0;
            int counter;
            ConsoleKeyInfo key;            
            while (true)
            {

                LoggedUser.WhoIsLogged();
                Console.WriteLine("Choose option by type correct number:");
                for (counter = 0; counter < SelectionOptions.Count; counter++) //list all movies, but format selected line by arrows
                {
                    if (currentLine == counter) //selected line
                    {
                        Console.WriteLine($"{SelectionOptions[counter]}", Console.BackgroundColor = ConsoleColor.White, Console.ForegroundColor = ConsoleColor.Black);
                    }
                    else //other lines
                    {
                        Console.WriteLine($"{SelectionOptions[counter]}", Console.BackgroundColor = ConsoleColor.Black, Console.ForegroundColor = ConsoleColor.White);
                    }
                }
                
                Console.WriteLine("", Console.BackgroundColor = ConsoleColor.Black, Console.ForegroundColor = ConsoleColor.White);

                key = Console.ReadKey(true);

                if (key.Key.ToString() == "DownArrow")
                {
                    currentLine++;
                    if (currentLine > SelectionOptions.Count - 1) currentLine = 0;
                }
                else if (key.Key.ToString() == "UpArrow")
                {
                    currentLine--;
                    if (currentLine < 0) currentLine = SelectionOptions.Count - 1;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    switch (currentLine)
                    {
                        case 0:
                            {
                                ListBrowseOptions();
                                GetUserChoiceInBrowseMenu();
                                break;
                            }
                        case 1:
                            {
                                ListSearchOptions();
                                GetUserChoiceInSearchMenu();
                                break;
                            }
                        case 2:
                            {
                                //TODO list films for kids
                                break;
                            }
                        case 3: //back to main panel
                            {                             
                                LoginPanel.MainPanel();
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
            }

        }

        public void InitializeMenu() 
        {            
            GetUserChoiceInMainMenu();
        }
    }
    
}

    
