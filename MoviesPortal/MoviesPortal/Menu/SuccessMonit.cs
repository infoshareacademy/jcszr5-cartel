using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesPortal.Menu
{
    public static class SuccessMonit
    {
        public static void DisplaySuccessAdnotation()
        {
            Console.Clear();
            Console.WriteLine("Success! Returning to menu...");
            Thread.Sleep(2000);
        }
    }
}
