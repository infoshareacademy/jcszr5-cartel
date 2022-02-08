public class MovieStore
{

    private static List<Movie> _movies = new List<Movie>();

    public static void AddMovie(Movie newMovie)
    {
        _movies.Add(newMovie);
    }

    public List<Movie> GetMovies()
    {
        return _movies.ToList();
    }
}
