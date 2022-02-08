using MoviesPortal.BusinessLayer;
using MoviesPortal.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPortal
{
    internal class ProgramService
    {
        IOHelper _iOHelper = new();
        MovieStoreService _movieStoreService = new();
        CreativePersonAgencyService _creativePersonAgencyService = new();

        public void AddNewMovie()
        {
            var newMovie = new Movie()
            {
                Title = _iOHelper.GetStringFromUser("Enter movie title: "),
                Director = AddPersonsList("director", CreativeRole.Director),
                Genre = _iOHelper.GetMovieGenre("Enter genre of the movie: "),
                ProductionYear = _iOHelper.GetProductionYearFromUser("Enter year of production: "),
                Description = _iOHelper.GetStringFromUser("Enter short description of the movie: "),
                IsForKids = _iOHelper.GetBoolFromUser("Is the movie alloved for children? (true/false): "),  //TODO change to Y/N
                ActorList = AddPersonsList("actor", CreativeRole.Actor)
            };
            _movieStoreService.AddNewMovie(newMovie);
        }

        List<CreativePerson> AddPersonsList(string message, CreativeRole role)
        {
            List<CreativePerson> persons = new List<CreativePerson>();
            var index = "";
            while (_iOHelper.GetBoolFromUser($"Do you want to add {index} {message}? (true/false)"))
            {
                var person = AddPerson(index, message, role);
                persons.Add(person);
                _creativePersonAgencyService.AddCreativePerson(person);
                index = "another";
            }
            return persons;
        }

        public CreativePerson AddPerson(string index, string message, CreativeRole role)
        {
            var name = _iOHelper.GetStringFromUser($"Enter name of {index} {message}: ");
            var surName = _iOHelper.GetStringFromUser($"Enter surname of {message}: ");
            var dateOfBirth = _iOHelper.GetDateTimeFromUser($"Enter date of bith of {message}");
            var person = new CreativePerson(name, surName, dateOfBirth, role);
            return person;
        }
    }
}
