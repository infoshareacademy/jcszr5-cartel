using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface ICreativePersonService
    {
        public Task<ICollection<CreativePersonModel>> GetAllCreativePersons();

        public Task<CreativePersonModel> GetCreativePersonsById(int id);

        public Task DeleteCreativePersonByIdAsync(int id);

        public Task CreateAsync(CreativePersonModel creativePersonModel);

        public Task EditAsync(int id, CreativePersonModel creativePersonModel);

    }

    public class CreativePersonService : ICreativePersonService
    {
        private readonly ICreativePersonRepository _creativePersonRepository;

        public CreativePersonService(ICreativePersonRepository creativePersonRepository)
        {
            _creativePersonRepository = creativePersonRepository;

        }

        public async Task<ICollection<CreativePersonModel>> GetAllCreativePersons()
        {
            var persons = await _creativePersonRepository.GetAllCreativePersons();
            return persons;
        }

        public async Task<CreativePersonModel> GetCreativePersonsById(int id) 
        {
            var person = await _creativePersonRepository.GetCreativePersonsById(id);
            return person;  
        }

        public async Task DeleteCreativePersonByIdAsync(int id)
        {
            await _creativePersonRepository.Delete(id);
        }

        public async Task CreateAsync(CreativePersonModel creativePersonModel)
        {
            await _creativePersonRepository.CreateAsync(creativePersonModel);
        }

        public async Task EditAsync(int id, CreativePersonModel creativePersonModel)
        {
            await _creativePersonRepository.EditAsync(id, creativePersonModel);
        }
    }
}
