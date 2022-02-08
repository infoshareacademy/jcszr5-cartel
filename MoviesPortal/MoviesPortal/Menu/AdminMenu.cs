using MoviesPortal.BusinessLayer;
using MoviesPortal.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MoviesPortal.Menu 
{
    internal class AdminMenu :IMenu
    {
        public ProgramService ProgramService = new();
        public MovieStoreService MovieStoreService = new();
        public IOHelper ioHelper = new IOHelper();
        public List<string> SelectionOptions
        {
            get
            {
                return new List<string>() {
                    "Add Movies",
                    "Edit Movies",
                    "Delete Movie",
                    "Add Actor/Director",
                    "Edit Actor/Director",
                    "Delete Actor/Director",
                    "Print all movies from database",
                    "Exit" };
            }
        }
        public void ListMainOptions()
        {
            var index = 1;
            Console.WriteLine("=======================================");
            foreach (var option in SelectionOptions)
            {
                Console.WriteLine($"{index}. {option}");
                index++;
            }
            Console.WriteLine("=======================================");
        }

        public void GetUserChoiceInMainMenu()
        {
            Console.WriteLine("\n Choose option by type correct number:");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine($"Adding new movie to database: \n");
                    ProgramService.AddNewMovie();
                    break;

                case "2":
                    break;

                case "3":
                    Console.Clear();
                    ProgramService.PrintAllMovies();
                    var movieIndexUserChoice = ioHelper.GetIntFromUser($"Enter index number of a movie you wont to delete: ");
                    var movieIndex = movieIndexUserChoice - 1;
                    MovieStoreService.DeleteMovie(movieIndex);
                    break;

                case "4":
                    Console.Clear();
                    CreativeRole creativeRole = ioHelper.GetCreativePersoneRole($"Which profession do you want to add?: ");
                    ProgramService.AddPerson("", creativeRole.ToString(), creativeRole);
                    Console.WriteLine($"Succes! New {creativeRole.ToString()} succesfully added!");
                    Thread.Sleep(1500);
                    Console.Clear();
                    break;
  
                case "5":
                    break;

                case "6":
                    break;

                case "7":
                    Console.Clear();
                    Console.WriteLine("List of all movies in database: \n");
                    ProgramService.PrintAllMovies();
                    Thread.Sleep(2000);
                    break;

                case "8":
                    Console.Clear();
                    Console.WriteLine("Are You sure? (y/n)");
                    string decision = Console.ReadLine();
                    if (decision == "y")
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        InitializeMenu();
                    }
                    break;

                default:
                {
                    Console.WriteLine("Please type correct number (from 1 to 7)");
                    GetUserChoiceInMainMenu();
                    break;
                }
            }
            InitializeMenu();
        }

        public void InitializeMenu()
        {
            ListMainOptions();
            GetUserChoiceInMainMenu();
        }
    }
}
