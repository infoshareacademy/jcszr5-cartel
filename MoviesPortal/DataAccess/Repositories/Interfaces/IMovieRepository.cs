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
        public Task Create(DbMovieModel dbMovieModel);
        public Task Delete(int id);
        public Task Edit(int id, DbMovieModel dbMovieModel);
        public Task<ICollection<DbMovieModel>> GetAll();
        public Task<DbMovieModel> GetById(int id);
    }
}
