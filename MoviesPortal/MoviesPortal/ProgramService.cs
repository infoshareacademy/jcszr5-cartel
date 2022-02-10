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
                IsForKids = _iOHelper.GetUserBinaryChoice("Is the movie alloved for children? ( Y / N ): "), 
                ActorList = AddPersonsList("actor", CreativeRole.Actor)
            };
            _movieStoreService.AddNewMovie(newMovie);
            Console.Clear();
            Console.WriteLine("Succes! New movie succesfully added!\n" );
            Thread.Sleep(1500);
        }

        List<CreativePerson> AddPersonsList(string message, CreativeRole role)
        {
            List<CreativePerson> persons = new List<CreativePerson>();
            var index = "";
            while(_iOHelper.GetUserBinaryChoice($"Do you want to add {index} {message}? ( Y / N)"))
            {
                var person = AddPerson(index, message, role);
                persons.Add(person);
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
            _creativePersonAgencyService.AddCreativePerson(person);
            return person;
        }

        public void PrintAllMovies()
        {
            var movies = _movieStoreService.GetAllMovies();
            if (movies.Count == 0)
            {
                Console.WriteLine($"There are no movies in database!");
                return;
            }
            else
            {
                var index = 1;
                foreach (var movie in movies)
                {
                    Console.WriteLine($"{index}. tile: \"{movie.Title}\",  production year: {movie.ProductionYear}, director{movie.Director} \n");
                    index++;
                }
            }
            
        }

        public void PrintAllCreativePersonsListByRole(CreativeRole creativeRoleToDelete)
        {
            List<CreativePerson> creativePersonsByRole = _creativePersonAgencyService.GetCreativePersonsListByRole(creativeRoleToDelete);
            if(creativePersonsByRole.Count == 0)
            {
                Console.WriteLine($"There is no {creativeRoleToDelete} in database!");
                Thread.Sleep(1500);
                return;
            }
            int index = 1;
            Console.WriteLine($"\n List of all {creativeRoleToDelete}s in database:\n");
            foreach(CreativePerson person in creativePersonsByRole)
            {
                Console.WriteLine($"{index}. {person.Name}  {person.SurName} {person.DateOfBirth}");
                index++;
            }
            Console.WriteLine("\n");
        }

        public void DeleteCreativePerson(CreativeRole creativeRoleToDelete)
        {
            List<CreativePerson> creativePersonsByRole = _creativePersonAgencyService.GetCreativePersonsListByRole(creativeRoleToDelete);
            if (creativePersonsByRole.Count > 0)
            {
                int indexOfPersonToDelate = _iOHelper.GetIntFromUser($"Enter index number of {creativeRoleToDelete} you want to delate") -1 ;
                var CreativePersonListByRole = _creativePersonAgencyService.GetCreativePersonsListByRole(creativeRoleToDelete);
                var personToDelate = CreativePersonListByRole[indexOfPersonToDelate];
                _creativePersonAgencyService.DeleteCreativePerson(personToDelate);
            }
            return;  
        }

        public void PrintMoviesByGenre(Genre movieGenre)
        {
            int index = 1;
            List<Movie> moviesByGenreList = _movieStoreService.GetMoviesByGenre(movieGenre);
            if (moviesByGenreList.Count == 0)
            {
                Console.WriteLine($"There are no movies in database!");
                return;
            }
            else
            {
                Console.WriteLine($"\nMovies of {movieGenre} genre:");
                foreach (Movie movie in moviesByGenreList)
                {
                    Console.WriteLine($"{index}. \"{movie.Title}\" director: {movie.Director} prod. {movie.ProductionYear} \n");
                    index++;
                }
            }
          
        }
    }
}
