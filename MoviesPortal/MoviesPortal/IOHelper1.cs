public class IOHelper
{
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
}