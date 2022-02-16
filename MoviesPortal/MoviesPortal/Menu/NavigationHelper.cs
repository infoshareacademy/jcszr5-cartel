using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPortal.Menu
{
    public static class NavigationHelper
    {
        public static void NavigateBetweenMovieTitles(List<Movie> MovieList)
        {
            
            int currentMovie = 0;
            int counter;
            ConsoleKeyInfo key;
            var sortedMovieList = MovieList.OrderBy(m => m.Title).ToList();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("All Movies in database. Select movie to read short description", Console.BackgroundColor = ConsoleColor.Black, Console.ForegroundColor = ConsoleColor.White);
                for (counter = 0; counter < sortedMovieList.Count; counter++) //list all movies, but format selected line by arrows
                {
                    if (currentMovie == counter) //selected line
                    {
                        Console.WriteLine($"{sortedMovieList[counter].Title}, {sortedMovieList[counter].ProductionYear}", Console.BackgroundColor = ConsoleColor.White, Console.ForegroundColor = ConsoleColor.Black);
                    }
                    else //other lines
                    {
                        Console.WriteLine($"{sortedMovieList[counter].Title}, {sortedMovieList[counter].ProductionYear}", Console.BackgroundColor = ConsoleColor.Black, Console.ForegroundColor = ConsoleColor.White);
                    }
                }
                Console.WriteLine(">>Press ESC to return...<<", Console.BackgroundColor = ConsoleColor.Black, Console.ForegroundColor = ConsoleColor.White);


                key = Console.ReadKey(true); //Wait until user press any key

                //if you pressed downarrow the currentMovie will decrase, UpArrow increase
                if (key.Key.ToString() == "DownArrow")
                {
                    currentMovie++;
                    if (currentMovie > sortedMovieList.Count - 1) currentMovie = 0;
                }
                else if (key.Key.ToString() == "UpArrow")
                {
                    currentMovie--;
                    if (currentMovie < 0) currentMovie = sortedMovieList.Count - 1;
                }
                else if (key.Key == ConsoleKey.Enter) //if you press enter:
                {
                    ShowDescription(sortedMovieList[currentMovie]);
                }
                else if (key.Key == ConsoleKey.Escape) //exit to menu by pressing escape
                {
                    break;
                }

            }
            
        }
        public static void NavigateBetweenMovieGenres(List<Movie> MovieList)
        {
            int currentMovie = 0;
            int counter;
            ConsoleKeyInfo key;
            var sortedMovieList = MovieList.OrderBy(m => m.Genre).ToList();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("All Movies in database. Select movie to read short description", Console.BackgroundColor = ConsoleColor.Black, Console.ForegroundColor = ConsoleColor.White);
                for (counter = 0; counter < sortedMovieList.Count; counter++) //list all movies, but format selected line by arrows
                {
                    if (currentMovie == counter) //selected line
                    {
                        Console.WriteLine($"{sortedMovieList[counter].Genre} >> {sortedMovieList[counter].Title}, {sortedMovieList[counter].ProductionYear}", Console.BackgroundColor = ConsoleColor.White, Console.ForegroundColor = ConsoleColor.Black);
                    }
                    else //other lines
                    {
                        Console.WriteLine($"{sortedMovieList[counter].Genre} >> {sortedMovieList[counter].Title}, {sortedMovieList[counter].ProductionYear}", Console.BackgroundColor = ConsoleColor.Black, Console.ForegroundColor = ConsoleColor.White);
                    }
                }
                Console.WriteLine(">>Press ESC to return...<<", Console.BackgroundColor = ConsoleColor.Black, Console.ForegroundColor = ConsoleColor.White);


                key = Console.ReadKey(true); //Wait until user press any key

                //if you pressed downarrow the currentMovie will decrase, UpArrow increase
                if (key.Key.ToString() == "DownArrow")
                {
                    currentMovie++;
                    if (currentMovie > sortedMovieList.Count - 1) currentMovie = 0;
                }
                else if (key.Key.ToString() == "UpArrow")
                {
                    currentMovie--;
                    if (currentMovie < 0) currentMovie = sortedMovieList.Count - 1;
                }
                else if (key.Key == ConsoleKey.Enter) //if you press enter:
                {
                    ShowDescription(sortedMovieList[currentMovie]);
                }
                else if (key.Key == ConsoleKey.Escape) //exit to menu by pressing escape
                {
                    break;
                }

            }
        }

        public static void ShowDescription(Movie movie)
        {
            Console.Clear();
            Console.WriteLine(movie.Description, Console.BackgroundColor = ConsoleColor.Black, Console.ForegroundColor = ConsoleColor.White);
            Console.ReadKey();
        }
    }
}
