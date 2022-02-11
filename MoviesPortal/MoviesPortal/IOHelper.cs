using MoviesPortal.BusinessLayer;
using MoviesPortal.DataLayer;
using System.Globalization;

public class IOHelper
{

    MovieStoreService _movieStoreService = new MovieStoreService();

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

        while (!DateTime.TryParseExact(GetStringFromUser($"{message} [{format}]"), format, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out result) || result > DateTime.Now)
        {
            Console.WriteLine("Not an valid date. Try again...\n");
            Thread.Sleep(1500);
        }
        return result;
    }

    public Genre GetMovieGenre(string message)
        {
            var correctValues = "";

            foreach (var genre in (Genre[])Enum.GetValues(typeof(Genre)))
            {
                correctValues += $"{genre}, ";
            }

            object result;
            while (!Enum.TryParse(typeof(Genre), GetStringFromUser($"{message} ({correctValues}):"), out result))
            {
                Console.WriteLine("Not a correct value - use one from the brackets. Try again...");
            }
            return (Genre)result;
        }

    public CreativeRole GetCreativePersoneRole(string message)
    {
        var correctValues = "";

        foreach (var role in (CreativeRole[])Enum.GetValues(typeof(CreativeRole)))
        {
            correctValues += $"{role}, ";
        }

        object result;
        while (!Enum.TryParse(typeof(CreativeRole), GetStringFromUser($"{message} ({correctValues}):"), out result))
        {
            Console.WriteLine("Not a correct value - use one from the brackets. Try again...");
        }
        return (CreativeRole)result;
    }

    public Genre GetMovieGenreFromUser(string message)
    {
        var correctValues = "";

        foreach (var genre in (Genre[])Enum.GetValues(typeof(Genre)))
        {
            correctValues += $"{genre}, ";
        }

        object result;
        while (!Enum.TryParse(typeof(Genre), GetStringFromUser($"{message} ({correctValues}):"), out result))
        {
            Console.WriteLine("Not a correct value - use one from the brackets. Try again...");
        }
        return (Genre)result;
    }


    public bool GetUserBinaryChoice(string message)
    {
       while(true)
        {
            string userChoice = GetStringFromUser(message);

            if (userChoice == "Y" || userChoice == "y")
            {
                return true;
            }
            else if (userChoice == "N" || userChoice == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("not a valid choice! Try again.");
                continue;
            }
        }
        
    }

}