using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CreativePersonRepository : ICreativePersonRepository
    {
        public Task Create(DbCreativePersonModel creativePerson)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task Edit(int id, DbCreativePersonModel creativePerson)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<DbCreativePersonModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<DbCreativePersonModel> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
