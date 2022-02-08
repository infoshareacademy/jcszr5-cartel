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
        IOHelper IOHelper = new();
        MovieStoreService MovieStoreService = new();
        CreativePersonAgencyService CreativePersonAgencyService = new();

        public void AddNewMovie()
        {
            var newMovie = new Movie()
            {
                Title = IOHelper.GetStringFromUser("Enter movie title: "),
                Director = AddPersonsList("director", CreativeRole.Director),
                Genre = IOHelper.GetMovieGenre("Enter genre of the movie: "),
                ProductionYear = IOHelper.GetProductionYearFromUser("Enter year of production: "),
                Description = IOHelper.GetStringFromUser("Enter short description of the movie: "),
                IsForKids = IOHelper.GetUserBinaryChoice("Is the movie alloved for children? ( Y / N ): "), 
                ActorList = AddPersonsList("actor", CreativeRole.Actor)
            };
            MovieStoreService.AddNewMovie(newMovie);
            Console.Clear();
            Console.WriteLine("Succes! New movie succesfully added!\n" );
            Thread.Sleep(1500);
        }

        List<CreativePerson> AddPersonsList(string message, CreativeRole role)
        {
            List<CreativePerson> persons = new List<CreativePerson>();
            var index = "";
            while(IOHelper.GetUserBinaryChoice($"Do you want to add {index} {message}? ( Y / N)"))
            {
                var person = AddPerson(index, message, role);
                persons.Add(person);
                CreativePersonAgencyService.AddCreativePerson(person);
                index = "another";
            }
            return persons;
        }

        public CreativePerson AddPerson(string index, string message, CreativeRole role)
        {
            var name = IOHelper.GetStringFromUser($"Enter name of {index} {message}: ");
            var surName = IOHelper.GetStringFromUser($"Enter surname of {message}: ");
            var dateOfBirth = IOHelper.GetDateTimeFromUser($"Enter date of bith of {message}");
            var person = new CreativePerson(name, surName, dateOfBirth, role);
            return person;
        }

        public void PrintAllMovies()
        {
            var movies = MovieStoreService.GetAllMovies();
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
    }
}
