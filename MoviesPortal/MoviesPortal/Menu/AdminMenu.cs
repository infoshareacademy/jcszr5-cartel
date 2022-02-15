using MoviesPortal.BusinessLayer;
using MoviesPortal.Data;
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
        public CreativePersonAgencyService CreativePersonAgencyService = new();
        public IOHelper ioHelper = new IOHelper();
        public List<string> SelectionOptions
        {
            get
            {
                return new List<string>() {
                    ">> Add Movies",
                    ">> Edit Movies",
                    ">> Delete Movie",
                    ">> Add Actor/Director",
                    ">> Edit Actor/Director",
                    ">> Delete Actor/Director",
                    ">> Print a list of all movies from database",
                    ">> Print a list f all Actors/Directors from database",
                    ">> Back to main menu" };
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
            int currentLine = 0;
            int counter;
            ConsoleKeyInfo key;
            while (true)
            {

                LoggedUser.WhoIsLogged();
                Console.WriteLine("Choose option by type correct number:");
                for (counter = 0; counter < SelectionOptions.Count; counter++)
                {
                    if (currentLine == counter)
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
                            Console.Clear();
                            Console.WriteLine($"Adding new movie to database: \n");
                            ProgramService.AddNewMovie();
                            break;

                        case 1:
                            break;

                        case 2:
                            Console.Clear();
                            ProgramService.PrintAllMovies();
                            var movieIndexUserChoice = ioHelper.GetIntFromUser($"Enter index number of a movie you wont to delete: ");
                            var movieIndex = movieIndexUserChoice - 1;
                            MovieStoreService.DeleteMovie(movieIndex);
                            break;

                        case 3:
                            Console.Clear();
                            CreativeRole creativeRole = ioHelper.GetCreativePersoneRole($"Which profession do you want to add?: ");
                            ProgramService.AddPerson("", creativeRole.ToString(), creativeRole);
                            Console.WriteLine($"Succes! New {creativeRole} succesfully added!");
                            Thread.Sleep(1500);
                            Console.Clear();
                            break;

                        case 4:
                            break;

                        case 5:
                            Console.Clear();
                            CreativeRole creativeRoleToDelete = ioHelper.GetCreativePersoneRole($"From which profession do you want to delete?: ");
                            ProgramService.PrintAllCreativePersonsListByRole(creativeRoleToDelete);
                            ProgramService.DeleteCreativePerson(creativeRoleToDelete);
                            break;

                        case 6:
                            Console.Clear();
                            Console.WriteLine("List of all movies in database: \n");
                            ProgramService.PrintAllMovies();
                            Thread.Sleep(2000);
                            break;

                        case 7:
                            CreativeRole creativeRoleToList = ioHelper.GetCreativePersoneRole($"From which profession do you want to list?: ");
                            ProgramService.PrintAllCreativePersonsListByRole(creativeRoleToList);
                            Thread.Sleep(1500);
                            break;

                        case 8:                            
                            LoginPanel.MainPanel();
                            break;

                        default:
                            {
                                Console.WriteLine("Please type correct number (from 1 to 7)");
                                GetUserChoiceInMainMenu();
                                break;
                            }
                    }
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
