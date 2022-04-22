using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    internal interface ICreativePersonRepository
    {
        public Task Create(CreativePersonModel creativePerson);
        public Task Delete(int id);
        public Task Edit(int id, CreativePersonModel creativePerson);
        public Task<ICollection<CreativePersonModel>> GetAll();
        public Task<CreativePersonModel> GetById(int id);
    }
}
