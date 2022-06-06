using DataAccess.Models;

namespace BusinessLogic.Services
{
    public interface IGenreService
    {
        Task AddNewGenre(string genre);
        Task DeleteGenre(int id);
        Task<ICollection<GenreModel>> GetAllGenres();
        Task<IList<GenreModel>> GetGenres(TvSeriesModel tvSeries);
        Task<IList<GenreModel>> GetGenres(MovieModel movie);
    }
}