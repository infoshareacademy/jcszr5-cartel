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
        public ProgramService ProgramService = new ProgramService();
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
                    ProgramService.AddNewMovie();
                    SuccessMonit.DisplaySuccessAdnotation();
                    break;

                case "2":
                    break;

                case "3":
                    break;

                case "4":
                    CreativeRole creativeRole = ioHelper.GetCreativePersoneRole($"Which profession do you want to add?: ");
                    ProgramService.AddPerson("", creativeRole.ToString(), creativeRole);
                    SuccessMonit.DisplaySuccessAdnotation();
                    break;
  
                case "5":
                    break;

                case "6":
                    break;

                case "7":
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
