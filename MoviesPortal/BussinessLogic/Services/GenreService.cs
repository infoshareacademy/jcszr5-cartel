using AutoMapper;
using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;

namespace BusinessLogic.Services
{
    
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        
        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            
        }

        public Task AddNewGenre(GenreModel genre)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGenre(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<GenreModel>> GetAllGenreList()
        {
            throw new NotImplementedException();
        }

        public Task<GenreModel> GetGenreById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
