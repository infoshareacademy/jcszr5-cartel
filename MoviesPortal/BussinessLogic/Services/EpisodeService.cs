using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{

    public interface IEpisodeService
    {
        public Task<ICollection<EpisodeModel>> GetAllEpisodes();
    }
    public class EpisodeService : IEpisodeService
    {
        private readonly IEpisodeRepository _episodeRepository;

        public EpisodeService(IEpisodeRepository episodeRepository)
        {
            _episodeRepository = episodeRepository;
        }

        public async Task<ICollection<EpisodeModel>> GetAllEpisodes()
        {
            return await _episodeRepository.GetAll();
        }
    }
}
