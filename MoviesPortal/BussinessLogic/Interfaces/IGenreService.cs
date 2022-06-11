using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IGenreService
    {
        public Task AddNewGenre(GenreModel genre);
        public Task DeleteGenre(int id);
        public Task<GenreModel> GetGenreById(int id);
        public Task<ICollection<GenreModel>> GetAllGenreList();
        
    }
}
