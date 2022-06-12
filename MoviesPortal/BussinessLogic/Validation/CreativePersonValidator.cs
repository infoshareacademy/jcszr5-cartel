using BusinessLogic.Services;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validation
{
    public class CreativePersonValidator : ICreativePersonValidator
    {
        private readonly ICreativePersonService _creativePersonService;
        public CreativePersonValidator(ICreativePersonService creativePersonService)
        {
            _creativePersonService = creativePersonService;
        }

        public async Task<bool> IsExistInDb(CreativePersonModel person)
        {
            var result = await _creativePersonService.GetAllCreativePersons();
            return result.Any(p =>p.Name == person.Name && p.SurName == person.SurName);
        }
    }
}
