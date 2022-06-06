using AutoMapper;
using DataAccess.DbContext;
using DataAccess.Models;
using DataAccess.Models.EntityAssigments;
using DataAccess.Repositories;

namespace BusinessLogic.Services
{

    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        private readonly MoviePortalContext _context;

        public MovieService(IMovieRepository movieRepository, IMapper mapper, MoviePortalContext context)
        {
            _movieRepository = movieRepository;
            _context = context;
        }

        public IQueryable<MovieModel> GetAllMovies()
        {
            var movies = _movieRepository.GetAllMovies();
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
