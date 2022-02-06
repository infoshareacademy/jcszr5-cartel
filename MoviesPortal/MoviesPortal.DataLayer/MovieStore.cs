public class MovieStore
{

    static List<Movie> _movies = new List<Movie>();

    public static void AddMovie(Movie newMovie)
    {
        _movies.Add(newMovie);
    }
}
