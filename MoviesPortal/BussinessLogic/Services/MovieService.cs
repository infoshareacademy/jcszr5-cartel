using AutoMapper;
using DataAccess.DbContext;
using DataAccess.Models;
using DataAccess.Models.EntityAssigments;
using DataAccess.Repositories;

namespace BusinessLogic.Services
{
    public interface IMovieService 
    {
        public Task<ICollection<MovieModel>> GetAllMoviesAsync();

        public Task<MovieModel> GetMovieIdByAsync(int? id);

        public Task DeleteMovieByIdAsync(int id);

    }

    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        private readonly MoviePortalContext _context;

        public MovieService(IMovieRepository movieRepository, IMapper mapper, MoviePortalContext context)
        {
            _movieRepository = movieRepository;
            _context = context;
        }

        public async Task<ICollection<MovieModel>> GetAllMoviesAsync()
        {
            var movies = await _movieRepository.GetAllMoviesAsync();
            return movies;
        }

        public async Task<MovieModel> GetMovieIdByAsync(int? id)
        {
            var movie = await _movieRepository.GetMovieIdByAsync(id);
            return movie;
        }

        public async Task DeleteMovieByIdAsync(int id)
        {
            await _movieRepository.DeleteMovieByIdAsync(id);
        }
    }
}
