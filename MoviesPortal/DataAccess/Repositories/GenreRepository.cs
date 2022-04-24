using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly MoviePortalContext _context;

        public GenreRepository(MoviePortalContext context)
        {
            _context = context;
        }
        public async Task Create(GenreModel genreModel)
        {
            _context.Genres.Add(genreModel);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var genre = _context.Genres.FirstOrDefault(x => x.Id == id);
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(int id, GenreModel genreModel)
        {
            var genre = _context.Genres.FirstOrDefault(x => x.Id == id);
            genre.Genre = genreModel.Genre;
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<GenreModel>> GetAll() => await _context.Genres.ToListAsync();
        

        public async Task<GenreModel> GetById(int id) => await _context.Genres.FirstOrDefaultAsync(x => x.Id == id);

    }
}
