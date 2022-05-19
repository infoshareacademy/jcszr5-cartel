using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ITvSeriesService
    {
        public Task CreateNewSeries(TvSeriesModel tvSeries);
        public Task DeleteSeries(int id);
        public Task <TvSeriesModel>GetById(int id);
        public Task <IQueryable<TvSeriesModel>> GetAll();
        public Task Edit(int id, TvSeriesModel tvSeries);
    }
}
