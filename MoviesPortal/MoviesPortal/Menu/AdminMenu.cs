using MoviesPortal.BusinessLayer;
using MoviesPortal.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MoviesPortal.Menu
{
    internal class AdminMenu : IMenu
    {
        ProgramService _programService = new();
        MovieStoreService MovieStoreService = new();
        CreativePersonAgencyService _creativePersonAgencyService = new();
        IOHelper _ioHelper = new IOHelper();
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
                    "Print a list of all movies from database",
                    "Browse a list of movies by genre",
                    "Print a list of all Actors/Directors from database",
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
                    MovieStoreService database = new();
                    database.SaveMoviesToJson();
                    break;

                case "2":
                    break;

                case "3":
                    Console.Clear();
                    _programService.PrintAllMovies();
                    var movieIndexUserChoice = _ioHelper.GetIntFromUser($"Enter index number of a movie you wont to delete: ");
                    var movieIndex = movieIndexUserChoice - 1;
                    MovieStoreService.DeleteMovie(movieIndex);
                    break;

                case "4":
                    Console.Clear();
                    CreativeRole creativeRole = _ioHelper.GetCreativePersoneRole($"Which profession do you want to add?: ");
                    _programService.AddPerson("", creativeRole.ToString(), creativeRole);
                    Console.WriteLine($"Succes! New {creativeRole} succesfully added!");
                    Thread.Sleep(1500);
                    Console.Clear();
                    break;

                case "5":
                    break;

                case "6":
                    Console.Clear();
                    CreativeRole creativeRoleToDelete = _ioHelper.GetCreativePersoneRole($"From which profession do you want to delete?: ");
                    _programService.PrintAllCreativePersonsListByRole(creativeRoleToDelete);
                    _programService.DeleteCreativePerson(creativeRoleToDelete);
                    break;

                case "7":
                    Console.Clear();
                    Console.WriteLine("List of all movies in database: \n");
                    _programService.PrintAllMovies();
                    Thread.Sleep(2000);
                    break;

                case "8":
                    //list films by genre
                    Genre userChoiceGenre = _ioHelper.GetMovieGenre("Chose movie genre you are looking for: ");
                    _programService.PrintMoviesByGenre(userChoiceGenre);
                    Thread.Sleep(1500);
                    break;



                case "9":
                    CreativeRole creativeRoleToList = _ioHelper.GetCreativePersoneRole($"From which profession do you want to list?: ");
                    _programService.PrintAllCreativePersonsListByRole(creativeRoleToList);
                    Thread.Sleep(1500);
                    break;

                case "10":
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
                    Console.WriteLine("Please type correct number (from 1 to 9)");
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
