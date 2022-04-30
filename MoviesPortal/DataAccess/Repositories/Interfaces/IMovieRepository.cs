using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IMovieRepository
    {
        public Task Create(MovieModel dbMovieModel);
        public Task DeleteMovieByIdAsync(int id);
        public Task Edit(int id, MovieModel dbMovieModel);
        public Task<ICollection<MovieModel>> GetAllMoviesAsync();
        public Task<MovieModel> GetMovieIdByAsync(int? id);
    }
}
