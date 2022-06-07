using DataAccess.Models;

namespace BusinessLogic.Services
{
    public interface IMovieService 
    {
        public IQueryable<MovieModel> GetAllMovies();

        public Task<MovieModel> GetMovieIdByAsync(int? id);

        public Task DeleteMovieByIdAsync(int id);
        public Task CreateNewMovie(MovieModel movie);
    }
}
