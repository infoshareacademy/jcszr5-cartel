using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface ISeasonService
    {
        public Task<SeasonModel> GetSeasonById(int id);
    }
    public class SeasonService : ISeasonService
    {
        private readonly ISeasonRepository _seasonRepository;

        public SeasonService(ISeasonRepository seasonRepository)
        {
            _seasonRepository = seasonRepository;
        }

        public async Task<SeasonModel> GetSeasonById(int id)
        {
            return await _seasonRepository.GetById(id);
        }
    }
}
