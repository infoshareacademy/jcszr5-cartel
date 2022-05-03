using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface ICreativePersonRepository
    {
        public Task CreateAsync(CreativePersonModel creativePerson);
        public Task Delete(int id);
        public Task EditAsync(int id, CreativePersonModel creativePerson);
        public Task<ICollection<CreativePersonModel>> GetAllCreativePersons();
        public Task<CreativePersonModel> GetCreativePersonsById(int id);
    }
}
