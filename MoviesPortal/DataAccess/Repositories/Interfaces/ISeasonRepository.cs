using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface ISeasonRepository
    {
        public Task Create(SeasonModel seasonModel);
        public Task Delete(int id);
        public Task Edit(int id, SeasonModel seasonModel);
        public Task<ICollection<SeasonModel>> GetAll();
        public Task<SeasonModel> GetById(int id);
    }
}
