using AutoMapper;
using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;

namespace BusinessLogic.Services
{
    
    public class GenreService 
    {
        private readonly IGenreRepository _genreRepository;
        private readonly ITvSeriesRepository _tvSeriesRepository;

        public GenreService(IGenreRepository genreRepository, IMapper mapper, ITvSeriesRepository tvSeriesRepository)
        {
            _genreRepository = genreRepository;
            _tvSeriesRepository = tvSeriesRepository;
        }

        public Task AddNewGenre(GenreModel genre)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGenre(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GenreModel>> GetAllGenresForTvSeries(TvSeriesModel tvSeries)
        {
            var genres = await _tvSeriesRepository.GetById(tvSeries.Id);
            
            return genres.Genres.ToList();
        }

        public Task<List<string>> GetGenresFromTvSeries(int id)
        {
            throw new NotImplementedException();
        }
    }
}
