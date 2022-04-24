using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IEpisodeRepository
    {
        public Task Create(EpisodeModel episodeModel);
        public Task Delete(int id);
        public Task Edit(int id, EpisodeModel episodeModel);
        public Task<ICollection<EpisodeModel>> GetAll();
        public Task<EpisodeModel> GetById(int id);
    }
}
