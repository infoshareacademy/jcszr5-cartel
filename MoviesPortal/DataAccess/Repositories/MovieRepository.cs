using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MoviePortalContext _context;

        public MovieRepository(MoviePortalContext context)
        {
            _context = context;
        }

        public async Task Create(MovieModel dbMovieModel)
        {
            _context.Movies.Add(dbMovieModel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovieByIdAsync(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(int id, MovieModel dbMovieModel)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if(movie != null)
            {
                movie.Title = dbMovieModel.Title;
                movie.ProductionYear = dbMovieModel.ProductionYear;
                movie.Description = dbMovieModel.Description;
                movie.Genres = dbMovieModel.Genres;
                //movie.CreativePersons = dbMovieModel.CreativePersons;
                movie.IsForKids = dbMovieModel.IsForKids;
                movie.PosterPath = dbMovieModel.PosterPath;
                movie.TrailerUrl = dbMovieModel.TrailerUrl;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<MovieModel>> GetAllMoviesAsync()
        {
            var result = await _context.Movies
                .Include(g => g.MovieGenres).ThenInclude(g => g.Genre)
                .Include(cp => cp.RoleCreativeMovie).ThenInclude(cp => cp.CreativePerson)
                .Include(cr => cr.RoleCreativeMovie).ThenInclude(cr => cr.Role)
                .ToArrayAsync();
            return result;
        }

        public async Task<MovieModel> GetMovieIdByAsync(int? id)
        {
            var result = await _context.Movies
                .Include(g => g.MovieGenres).ThenInclude(g => g.Genre)
                .Include(cp => cp.RoleCreativeMovie).ThenInclude(cp => cp.CreativePerson)
                .Include(r => r.RoleCreativeMovie).ThenInclude( r => r.Role)
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }


    }
}
