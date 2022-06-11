using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesPortal.DataLayer.Models;

namespace MoviesPortal.BusinessLayer.SearchEngine
{
    internal class ByActor : ISearch, IPrinter
    {
        private List<Movie> movies;
        public List<Movie> Search(string input)
        {
            MovieStoreService movieStoreService = new();
            movieStoreService.LoadMoviesFromJson(); //załaduj z pliku JSON do zmiennej MovieStore
            movies = MovieStore.GetMovies(); //zapisz w liscie movies wszystkie filmy
            
            var results = new List<Movie>();
            var actorList = new List<CreativePerson>();
            foreach (var movie in movies)
            {
                var isAnyWantedActor = movie.ActorList.Any(actor => actor.SurName.ToLower().Contains(input.ToLower()));
                if (isAnyWantedActor)
                {
                    results.Add(movie);
                }

            }
            
            return results; //possible null reference. Only god know what will happen
        }

        public void PrintMovies(List<Movie> MovieList)
        {
            if (MovieList.Count == 0)
            {
                Console.WriteLine("Nothing found...");
            }
            else
            {
                int currentMovie = 0;
                int counter;
                ConsoleKeyInfo key;
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Here are results... Select movie to read short description", Console.BackgroundColor = ConsoleColor.Black, Console.ForegroundColor = ConsoleColor.White);
                    for(counter = 0; counter < MovieList.Count; counter++) //list all movies, but format selected line by arrows
                    {
                        if(currentMovie==counter) //selected line
                        {
                            Console.WriteLine($"{MovieList[counter].Title}, {MovieList[counter].ProductionYear}", Console.BackgroundColor = ConsoleColor.White, Console.ForegroundColor = ConsoleColor.Black);
                        }
                        else //other lines
                        {
                            Console.WriteLine($"{MovieList[counter].Title}, {MovieList[counter].ProductionYear}", Console.BackgroundColor = ConsoleColor.Black, Console.ForegroundColor = ConsoleColor.White);
                        }
                    }
                    Console.WriteLine(">>Press ESC to return...<<", Console.BackgroundColor = ConsoleColor.Black, Console.ForegroundColor = ConsoleColor.White);

                    key = Console.ReadKey(true); //Wait until user press any key

                    //if you pressed downarrow the currentMovie will decrase, UpArrow increase
                    if(key.Key.ToString() == "DownArrow")
                    {
                        currentMovie++;
                        if (currentMovie > MovieList.Count - 1) currentMovie = 0;
                    }
                    else if (key.Key.ToString()=="UpArrow")
                    {
                        currentMovie--;
                        if (currentMovie < 0) currentMovie = MovieList.Count - 1;
                    }
                    else if (key.Key == ConsoleKey.Enter) //if you press enter:
                    {
                        ShowDescription(MovieList[currentMovie]);                        
                    }
                    else if (key.Key == ConsoleKey.Escape) //exit to menu by pressing escape
                    {
                        break; 
                    }

                }
            }
            
        }

        public void ShowDescription(Movie movie)
        {
            Console.Clear();
            Console.WriteLine(movie.Description, Console.BackgroundColor = ConsoleColor.Black, Console.ForegroundColor = ConsoleColor.White);
            Console.ReadKey();
        }
    }
}
