using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class TvSeriesService : ITvSeriesService
    {
        private readonly ITvSeriesRepository tvSeriesRepository;
        private readonly ICreativePersonRepository creativePersonRepository;
        private readonly ISeasonRepository seasonRepository;
        private readonly IEpisodeRepository episodeRepository;
        private readonly IGenreRepository genreRepository;

        public TvSeriesService(ITvSeriesRepository tvSeriesRepository, ICreativePersonRepository creativePersonRepository, IGenreRepository genreRepository, IEpisodeRepository episodeRepository, ISeasonRepository seasonRepository)
        {
            this.tvSeriesRepository = tvSeriesRepository;
            this.creativePersonRepository = creativePersonRepository;
            this.genreRepository = genreRepository;
            this.episodeRepository = episodeRepository;
            this.seasonRepository = seasonRepository;
        }

        public Task CreateNewSeries(TvSeriesModel tvSeries)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSeries(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TvSeriesModel> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
