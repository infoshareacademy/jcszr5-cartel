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
    public class SeasonRepository : ISeasonRepository
    {
        private readonly MoviePortalContext _context;

        public SeasonRepository(MoviePortalContext context)
        {
            _context = context;
        }

        public async Task Create(SeasonModel seasonModel)
        {
            _context.Seasons.Add(seasonModel);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var season = _context.Seasons.FirstOrDefault(s => s.Id == id);
            _context.Seasons.Remove(season);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(int id, SeasonModel seasonModel)
        {
            var season = _context.Seasons.FirstOrDefault(s => s.Id == id);
            season.SeasonNumber = seasonModel.SeasonNumber;
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<SeasonModel>> GetAll() => await _context.Seasons.ToListAsync();


        public async Task<SeasonModel> GetById(int id) => await _context.Seasons.FirstOrDefaultAsync(se => se.Id == id);
        
    }
}
