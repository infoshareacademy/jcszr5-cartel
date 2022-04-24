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
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly MoviePortalContext _context;

        public EpisodeRepository(MoviePortalContext context)
        {
            _context = context;
        }

        public async Task Create(EpisodeModel episodeModel)
        {
            _context.Episodes.Add(episodeModel);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var episode = _context.Episodes.FirstOrDefault(ep => ep.Id == id);
            _context.Episodes.Remove(episode);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(int id, EpisodeModel episodeModel)
        {
            var episode = _context.Episodes.FirstOrDefault(ep => ep.Id == id);
            episode.Title = episodeModel.Title;
            episode.Description = episodeModel.Description;
            await _context.SaveChangesAsync();
            
        }

        public async Task<ICollection<EpisodeModel>> GetAll() => await _context.Episodes.ToArrayAsync();

        public async Task<EpisodeModel> GetById(int id) => await _context.Episodes.FirstOrDefaultAsync(x => x.Id == id);
        
    }
}
