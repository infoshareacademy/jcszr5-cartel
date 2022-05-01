using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CreativePersonRepository : ICreativePersonRepository
    {
        private readonly MoviePortalContext _context;

        public CreativePersonRepository(MoviePortalContext context)
        {
            _context = context;
        }

        public async Task Create(CreativePersonModel creativePerson)
        {
            _context.CreativePersons.Add(creativePerson);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var result = await _context.CreativePersons.FindAsync(id);
            _context.CreativePersons.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(int id, CreativePersonModel creativePerson)
        {
            var creativePersonOld = _context.CreativePersons.Find(id);
            if(creativePersonOld != null)
            {
                creativePersonOld.Name = creativePerson.Name;
                creativePersonOld.SurName = creativePerson.SurName;
                creativePersonOld.DateOfBirth = creativePerson.DateOfBirth;
                creativePersonOld.Movies = creativePerson.Movies;
                
            }
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<CreativePersonModel>> GetAll()
        {
            return await _context.CreativePersons.ToArrayAsync();
        }

        public async Task<CreativePersonModel> GetById(int id)
        {
            return await _context.CreativePersons.FindAsync(id);
        }
    }
}
