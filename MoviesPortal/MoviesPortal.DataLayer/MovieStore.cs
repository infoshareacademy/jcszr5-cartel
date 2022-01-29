public class MovieStore
{

    List<Movie> _movies = new List<Movie>();



    public void AddMovie(Movie newMovie)
    {
        _movies.Add(newMovie);
    }
}
