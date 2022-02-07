using MoviesPortal.BusinessLayer;
using System.Globalization;

public class IOHelper
{

    MoviesService _moviesService = new MoviesService();

    public string GetStringFromUser(string message)
    {
        Console.WriteLine(message);
        return Console.ReadLine();
    }

    public int GetIntFromUser(string message)
    {
        int result;
        while (!int.TryParse(GetStringFromUser(message), out result))
        {
            Console.WriteLine("Not a valid integer! Try again.");
        }
        return result;
    }


    public bool GetBoolFromUser(string message)
    {
        bool result;
        while (!bool.TryParse(GetStringFromUser(message), out result))
        {
            Console.WriteLine("Not a valid integer! Try again.");
        }
        return result;
    }

    public float GetFloatFromUser(string message)
    {
        float result;
        while (!float.TryParse(GetStringFromUser(message), out result))
        {
            Console.WriteLine("Not a valid integer! Try again.");
        }
        return result;
    }

    public int GetProductionYearFromUser(string message)
    {
        int result;
        while (!int.TryParse(GetStringFromUser(message), out result))
        {
            Console.WriteLine("Not a valid integer! Try again.");
        }
        if(result < 1900 || result > 2022)
        {
            Console.WriteLine("Film indystry existed roughly since 1900 y till now. Enter the correct year of production of the film");
            GetProductionYearFromUser(message);
        }
        return result;
    }

    public DateTime GetDateTimeFromUser(string message)
    {
        string format = "dd/MM/yyyy";
        DateTime result;

        while (!DateTime.TryParseExact(
            GetStringFromUser($"{message} [{format}]"),
            format,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out result))
        {
            Console.WriteLine("Not an valid date. Try again...");
        }

        return result;
    }

    public void AddNewMovie()
    {
        var newMovie = new Movie()
        {
            Title = GetStringFromUser("Enter movie title: "),
            Director = AddPersonsList("director"),
            Genre = GetStringFromUser("Enter movie genre (action, adventure, animated, comedy, drama, fantasy, historical, horror, sciFi, thriller, western"),
            ProductionYear = GetProductionYearFromUser("Enter year of production: "),
            Description = GetStringFromUser("Enter short description of the movie: "),
            IsForKids = GetBoolFromUser("Is the movie alloved for children? (true/false): "),  //TODO change to Y/N
            ActorList = AddPersonsList("actor")
            //TODO:
            // - add actor => adding new person,
            // - add actor from the list of persons in the system
        };
        _moviesService.AddNewMovie(newMovie);
    }

    List<Person> AddPersonsList(string message)
    {
        List<Person> persons = new List<Person>();
        var index = "";
        while (GetBoolFromUser($"Do you want to add {index} {message}? (true/false)"))
        {
            var person = AddPerson(index, message);
            persons.Add(person);
            index = "another";
        }
        return persons;
    }

    public Person AddPerson(string index, string message)
    {
        var name = GetStringFromUser($"Enter name of {index} {message}: ");
        var surName = GetStringFromUser($"Enter surname of {message}: ");
        var person = new Person(name, surName);
        return person;
    }

}