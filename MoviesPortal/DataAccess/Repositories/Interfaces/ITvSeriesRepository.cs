using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface ITvSeriesRepository
    {
        public Task Create(TvSeriesModel tvSeriesModel);
        public Task Delete(int id);
        public Task Edit(int id, TvSeriesModel tvSeriesModel);
        public Task<ICollection<TvSeriesModel>> GetAll();
        public Task<TvSeriesModel> GetById(int id);
    }
}
