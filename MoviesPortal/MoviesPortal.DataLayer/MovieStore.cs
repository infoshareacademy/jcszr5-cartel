using MoviesPortal.DataLayer;

public class MovieStore
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

    public static List<Movie> GetMoviesByGenre(Genre genre)
    {
        List<Movie> moviesByGenre = new();
        foreach (Movie movie in _movies)
        {
            if (movie.Genre == genre)
            {
                moviesByGenre.Add(movie);
            }
            else
            {
                continue;
            }
        }
        return moviesByGenre;
    }
}
