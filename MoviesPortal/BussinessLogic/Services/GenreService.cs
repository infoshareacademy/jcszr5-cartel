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

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task AddNewGenre(string genre)
        {
            GenreModel genreModel = new GenreModel();
            genreModel.Genre = genre;
            await _genreRepository.Create(genreModel);
        }

        public async Task DeleteGenre(int id)
        {
            await _genreRepository.Delete(id);
        }

        public async Task<ICollection<GenreModel>> GetAllGenres()
        {
            return await _genreRepository.GetAll();
        }

        public async Task<IList<GenreModel>> GetGenres(TvSeriesModel tvSeries)
        {
            var genres = tvSeries.Genres.ToList();

            return genres;
        }

        public async Task<IList<GenreModel>> GetGenres(MovieModel movie)
        {
            var genres = movie.Genres.ToList();

            return genres;
        }


    }
}
