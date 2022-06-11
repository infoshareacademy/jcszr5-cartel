using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IGenreRepository
    {
        public Task Create(GenreModel genreModel);
        public Task Delete(int id);
        public Task Edit(int id, GenreModel genreModel);
        public Task<ICollection<GenreModel>> GetAll();
        public Task<GenreModel> GetById(int id);
    }
}
