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
        public Task Create(DbCreativePersonModel creativePerson);
        public Task Delete(int id);
        public Task Edit(int id, DbCreativePersonModel creativePerson);
        public Task<ICollection<DbCreativePersonModel>> GetAll();
        public Task<DbCreativePersonModel> GetById(int id);
    }
}
