public class Movie
{

    private static List<Movie> _movies = new List<Movie>();

    public static void AddMovie(Movie newMovie)
    {
        _movies.Add(newMovie);
    }

    public static List<Movie> GetMovies()
    {
        return _movies.ToList();
    }

    public static void DeleteMovie(int movieIndex)
    {
        var movie = _movies[movieIndex].Title.ToString();
        _movies.RemoveAt(movieIndex);
        Console.WriteLine($"The movie \"{movie}\" has been succesfully delated. ");
        Thread.Sleep(2000);
    }
}
